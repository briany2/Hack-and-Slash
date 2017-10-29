using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is used to manage the fireball's speed on creation.
// Created by Brian Yu.
public class FireballControl : MonoBehaviour {
    public Vector2 speed;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        // Gets the rigid body component of the fireball.
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = speed;
	}
}
