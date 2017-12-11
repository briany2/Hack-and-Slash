using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour {
    public AudioClip damageSound;
    private AudioSource source;
    Animator playerAnimator;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
			Destroy (gameObject);
			collider.gameObject.SendMessage ("TakeDamage", 25);
        }
    }
}
