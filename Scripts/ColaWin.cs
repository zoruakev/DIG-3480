using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaWin : MonoBehaviour {

    Vector2 tempPos;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempPos = transform.position;
            tempPos.x += .5f;
            transform.position = tempPos;
        }
	}
}
