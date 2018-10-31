using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gamecontroller;

	// Use this for initialization
	void Start ()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gamecontroller = gameControllerObject.GetComponent<GameController>();
        }
        if (gamecontroller == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gamecontroller.GameOver();
        }
        gamecontroller.AddScore (scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
