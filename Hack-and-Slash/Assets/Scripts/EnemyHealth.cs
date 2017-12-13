using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Enemy Health system(On contact)
//Written by Cheng Hang
public class EnemyHealth : MonoBehaviour {
    public AudioSource source;
    public int startingHealth = 50;
	public int currentHealth;
	bool isDead;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update () {

    }

	public void TakeDamage (int amount) {
		currentHealth -= amount;
        source.Play();
        if (currentHealth <= 0 && !isDead) {
			Death ();
		}
    }

    void Death () {
		isDead = true;
        gameObject.transform.position = new Vector2(999999f, 999999f);
        Object.Destroy (this.gameObject, 1.5f);
		ScoreManager.score++;
	}
}
