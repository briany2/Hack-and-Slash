using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class allows an enemy to be damaged
// Created by Brian Yu
public class DamageEnemy : MonoBehaviour {
    public AudioClip damageSound;
    private AudioSource source;
    Animator playerAnimator;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(damageSound,0.5f);
            playerAnimator.Play("FrogDeath");
            Destroy(collider.gameObject);
            gameObject.transform.position = new Vector2(99999,99999);
            Destroy(gameObject, damageSound.length);
            ScoreManager.score++;
        }
    }
}
