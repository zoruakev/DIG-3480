﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip beam;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating ("Fire", delay, fireRate);
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        GetComponent<AudioSource>().PlayOneShot(beam);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
