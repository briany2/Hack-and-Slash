using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is used to detect the player object, then move and rotate the enemy object towards the player object.
// Created by Cheng Hang.
public class EyeballMovement : MonoBehaviour {
	private GameObject wayPoint;
	public GameObject EyeballLaser;
	private float speed = 3f;
	public float projectileSpeed = 7.5f;
	// Finds the player object
	void Start () {
		wayPoint = GameObject.Find("PlayerWitch");
	}

	// Update is called once per frame
	void Update () {
		// Takes the position and moves the eyeball.
		Vector3 localPosition = wayPoint.transform.position - transform.position;
		localPosition = localPosition.normalized;
		transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, localPosition);
	}

	public void Shoot() {
		// Makes the eyeball shoot a laser.
		Vector3 localPosition = (wayPoint.transform.position - transform.position).normalized;
		Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(localPosition.x, -localPosition.y) * Mathf.Rad2Deg + 90);
		GameObject projectile = Instantiate (EyeballLaser, this.transform.position, rotation);
		projectile.GetComponent<Rigidbody2D> ().velocity = localPosition * projectileSpeed;
	}
}
