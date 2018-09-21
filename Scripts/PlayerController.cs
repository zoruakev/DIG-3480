using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text ScoreText;

    private Rigidbody rb;
    private int count;
    private int score;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        countText.text = "Count: " + count.ToString();
        ScoreText.text = "Score: " + score.ToString();
        winText.text = "";
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float colorR = Mathf.Abs(transform.position.x / 10);
        float colorG = Mathf.Abs(transform.position.y / 10);
        float colorB = Mathf.Abs(transform.position.z / 10);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Color colornow = new Vector4(colorR, colorG, colorB, 0.0f);

        GetComponent<Renderer>().material.color = colornow;
        print(transform.position);

        rb.AddForce(movement * speed);
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    } 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            SetScoreText();
            if (count == 12)
            {
                transform.position = new Vector3(23.0f,transform.position.y,6.0f);
            }
        }

        else if (other.gameObject.CompareTag("Bad Block"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetCountText();
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 17)
        {
            winText.text = "You finished with a score of:" + score.ToString();
        }
    }

}
