using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This code is used to damage the enemy and play a sound on hit.
// Created by: Brian Yu
public class DamageEnemy : MonoBehaviour {
    public AudioClip damageSound;
    private AudioSource source;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
			Destroy (gameObject);
			collider.gameObject.SendMessage ("TakeDamage", 25);
        }
    }
}
