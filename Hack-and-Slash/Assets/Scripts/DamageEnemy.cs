using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD
public class DamageEnemy : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
		{
=======
// This code is used to damage the enemy and play a sound on hit.
// Created by: Brian Yu
public class DamageEnemy : MonoBehaviour {
    public AudioClip damageSound;
    private AudioSource source;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
>>>>>>> GameOver
			Destroy (gameObject);
			collider.gameObject.SendMessage ("TakeDamage", 25);
        }
    }
}
