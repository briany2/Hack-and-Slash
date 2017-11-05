using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the player movement and attacks, including shooting projectiles.
// Created by: Brian Yu
public class Movement : MonoBehaviour {

    public float speed = 4f;
    public float timer = 0f - 3;
    public GameObject LeftFireball;
    public GameObject wayPoint;
    //Used to prevent an infinite amount of fireballs.
    public int mana = 100;
    public int manaCost = 5;
    public int manaRestore = 1;
    //Used to prevent massive amounts of fireballs at once
    public bool fireballCounter = true;

	// Use this for initialization
	void Start () {
        wayPoint = GameObject.Find("PlayerWitch");
    }

    // Update is called once per frame
    void FixedUpdate () {
        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            timer = 0;
            if (!fireballCounter) { fireballCounter = true; }
            if (mana < 100) { mana += manaRestore; }
        }
        // Moves Character Left-Right with (A and D keys, or Left and Right Arrows)
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.smoothDeltaTime, 0f, 0f));
        }
        // Moves Character Up-Down with (W and S keys, or Up and Down Arrows)
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.smoothDeltaTime, 0f));
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (fireballCounter)
            {
                if (mana < manaCost) { return; }
                if (mana >= manaCost) { mana -= manaCost; }
                // Obtains and Tracks the Player object.
                Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction = target - myPos;
                // Used to rotate the Projectile in the correct position and shoot it in the correct direction.
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg + 90);
                GameObject projectile = Instantiate(LeftFireball, wayPoint.transform.position, rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
                fireballCounter = !fireballCounter;
            }
        }
    }
}
