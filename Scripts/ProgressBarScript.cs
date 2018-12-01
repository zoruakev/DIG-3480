using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour {

    Animator anim;

    private Rigidbody2D rb2d;

    Image progressBar;
    float maxProgress = 500;
    public static float progress;
    public Text endText;
    private float timer;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        progressBar = GetComponent<Image>();
        anim = GetComponent<Animator>();
        progress = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddProgress();
        }
        progressBar.fillAmount = progress / maxProgress;
	}

    private void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 10)
        {
            endText.text = "Maybe next time!";
            StartCoroutine(ByeAfterDelay(2));
        }
    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        //GameLoader.gameOn = false;
    }

    public void AddProgress()
    {
        progress += 10;
    }

    void SetWinText()
    {
        if (progress == 1)
        {
            endText.text = "Fizzy Cola!";
            StartCoroutine(ByeAfterDelay(2));
        }
    }
}
