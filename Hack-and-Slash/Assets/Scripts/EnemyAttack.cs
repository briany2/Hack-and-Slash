using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy attack system (On contact)
// Written by Cheng Hang
public class EnemyAttack : MonoBehaviour {
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
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
	}

	void Attack () {
		timer = 0f;
		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
