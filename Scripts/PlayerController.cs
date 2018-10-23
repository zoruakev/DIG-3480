using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator anim;

    private AudioSource source;
    public AudioClip jumpClip;
    public AudioClip coinClip;
    public AudioClip goombaClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    private Rigidbody2D rb2d;
    public float speed;
    private float moveVelocity;
    public float jumpforce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        moveVelocity = 0f;
      grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinClip);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(goombaClip);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("CoinBlock"))
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinClip);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            moveVelocity = speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            moveVelocity = -speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpforce);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(jumpClip);
        }

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y); 

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }

        anim.SetFloat("speed", rb2d.velocity.x);

        if (rb2d.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (rb2d.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
