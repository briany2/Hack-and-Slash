using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Eyeball attack system (On contact and laser shot)
// Written by Cheng Hang
public class EyeballAttack : MonoBehaviour {
	public float timeBetweenAttacks = 0.5f;
	public float timeBetweenShots = 2.5f;
	public int attackDamage = 10;

	GameObject player;
	PlayerHealth playerHealth;
	EyeballMovement eyeball;
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		eyeball = this.GetComponent <EyeballMovement> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject == player) {
			playerInRange = false;
		}
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange) {
			Attack ();
		}
		if (timer >= timeBetweenShots) {
			eyeball.Shoot ();
			timer = 0f;
		}
	}

	void Attack () {
		timer = 0f;
		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
