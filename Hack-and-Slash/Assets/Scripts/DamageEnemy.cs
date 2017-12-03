﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class allows an enemy to be damaged
// Created by Brian Yu
public class DamageEnemy : MonoBehaviour {
    public AudioClip damageSound;
    private AudioSource source;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(damageSound,1);
            Destroy(collider.gameObject);
            Destroy(gameObject);
            ScoreManager.score++;
        }
    }
}
