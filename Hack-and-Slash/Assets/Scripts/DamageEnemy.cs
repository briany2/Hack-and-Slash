using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour {
<<<<<<< HEAD
    public AudioClip damageSound;
    private AudioSource source;
    Animator playerAnimator;
=======
	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		
	}
>>>>>>> eyeballEnemy

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
<<<<<<< HEAD
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(damageSound,0.5f);
            playerAnimator.Play("FrogDeath");
            Destroy(collider.gameObject);
            gameObject.transform.position = new Vector2(99999,99999);
            Destroy(gameObject, damageSound.length);
            ScoreManager.score++;
=======
		{
			Destroy (gameObject);
			collider.gameObject.SendMessage ("TakeDamage", 25);
>>>>>>> eyeballEnemy
        }
    }
}
