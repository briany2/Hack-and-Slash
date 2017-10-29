using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is used to destroy a fireball after a set amount of time if it has not collided with an enemy.
// Created by: Brian Yu
public class DestroyWithDelay : MonoBehaviour {

    public float delay;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
