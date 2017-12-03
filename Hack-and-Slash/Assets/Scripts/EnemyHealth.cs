using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 50;
	public int currentHealth;

	bool isDead;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void TakeDamage (int amount) {
		currentHealth -= amount;
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	void Death () {
		isDead = true;
		Object.Destroy (this.gameObject);
		ScoreManager.score++;
	}
}
