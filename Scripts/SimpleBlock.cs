using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBlock : MonoBehaviour {

    Animator anim;
    private Rigidbody2D rb2d;
    public int blockHealth;
    private int currentHealth;
    public Sprite deadBlock;

    public LayerMask whatIsGround;
    private bool wallHit;
    public Transform playerHitBox;
    public float wallHitHeight;
    public float wallHitWidth;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = blockHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            currentHealth = blockHealth - 1;
        }

        if (blockHealth <= 0)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = deadBlock;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(playerHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }

}
