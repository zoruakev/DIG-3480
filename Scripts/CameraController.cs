using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Transform target;

    [SerializeField]
    private float maxX;

    [SerializeField]
    private float maxY;

    [SerializeField]
    private float minX;

    [SerializeField]
    private float minY;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), Mathf.Clamp(target.position.y, minY, maxY), transform.position.z);
	}
}
