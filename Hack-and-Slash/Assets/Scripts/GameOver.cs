using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is used to play the game over clip when player dies.
// Created by: Brian Yu
public class GameOver : MonoBehaviour {

    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    public AudioClip gameOverSound;
    private AudioSource source;
    bool check = true;

    Animator anim;
    float restartTimer;

	void Awake () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.currentHealth <= 0)
        {
            if (check)
            {
                source.PlayOneShot(gameOverSound, 0.7f);
                check = false;
            }
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene("Menu");
            }
        }
	}
}
