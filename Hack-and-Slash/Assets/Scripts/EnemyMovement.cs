using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is used to detect the player object, then move the enemy object towards the player object.
// Created by Brian Yu.
public class EnemyMovement : MonoBehaviour {
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    private float speed = 3f;
    // Finds the player object
	void Start () {
        wayPoint = GameObject.Find("PlayerWitch");
	}
	
	// Update is called once per frame
	void Update () {
        // Takes the position and moves enemy character.
        float speedMultiplier = ScoreManager.score / 50;
        speed += speedMultiplier;
        Vector3 localPosition = wayPoint.transform.position - transform.position;
        localPosition = localPosition.normalized;
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
    }
}
