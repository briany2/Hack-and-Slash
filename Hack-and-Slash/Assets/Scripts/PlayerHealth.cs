using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    //Health system based on classic HP bar
    //Written by Cheng Hang
    public int startingHealth = 100;
    public int currentHealth;
    public Slider HealthSlider;
    public Image DamageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    Animator playerAnimator;
    int damagehash;

    Movement playerMovement;
    bool isDead;
    bool isDamaged;


    // Use this for initialization
    void Start()
    {
        playerMovement = GetComponent<Movement>();
        playerAnimator = GetComponent<Animator>();

        damagehash = Animator.StringToHash("Damage");
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged)
        {
            DamageImage.color = flashColor;
            playerAnimator.SetTrigger(damagehash);
        }
        else
        {
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        isDamaged = false;
    }

    public void TakeDamage(int amount)
    {
        isDamaged = true;
        currentHealth -= amount;
        HealthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        playerMovement.enabled = false;
    }
}
