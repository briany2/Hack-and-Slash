using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the player movement and attacks, including shooting projectiles.
// Created by: Brian Yu
public class Movement : MonoBehaviour {
    public float speed = 4f;
    public float timer = 0f - 3;
    public GameObject leftFireball;
    public GameObject wayPoint;
    private AudioSource source;
    public AudioClip fireballSound;
    //Used to prevent massive amounts of fireballs at once
    public bool fireballCounter = true;

    Animator playerAnimator;
    int animDirectionHash;

    void Awake()
    {
        source = GetComponent<AudioSource>();    
    }

    // Use this for initialization
    void Start()
    {
        wayPoint = GameObject.Find("PlayerWitch");
        playerAnimator = GetComponent<Animator>();
        animDirectionHash = Animator.StringToHash("Direction");
    }

    // Update is called once per frame
    void FixedUpdate () {
        float horAxis = Input.GetAxisRaw("Horizontal");
        float vertAxis = Input.GetAxisRaw("Vertical");

        // Moves Character Left-Right with (A and D keys, or Left and Right Arrows)
        if (horAxis > 0.5f || horAxis < -0.5f)
        {
            transform.Translate(new Vector3(horAxis * speed * Time.smoothDeltaTime, 0f, 0f));
        }
        // Moves Character Up-Down with (W and S keys, or Up and Down Arrows)
        if (vertAxis > 0.5f || vertAxis < -0.5f)
        {
            transform.Translate(new Vector3(0f, vertAxis * speed * Time.smoothDeltaTime, 0f));
        }

        // Set animation direction
        // 0 = down, 1 = up, 2 = left, 3 = right

        if (Mathf.Abs(horAxis) > Mathf.Abs(vertAxis))
        {
            if (horAxis > 0.5f)
            {
                playerAnimator.SetInteger(animDirectionHash, 3);
            }
            else if (horAxis < -0.5f)
            {
                playerAnimator.SetInteger(animDirectionHash, 2);
            }

        }
        else
        {
            if (vertAxis > 0.5f)
            {
                playerAnimator.SetInteger(animDirectionHash, 1);
            }
            else if (vertAxis < -0.5f)
            {
                playerAnimator.SetInteger(animDirectionHash, 0);
            }
        }

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            timer = 0;
            if (!fireballCounter) { fireballCounter = true; }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (fireballCounter)
            {
                source.PlayOneShot(fireballSound, 1);
                // Obtains and Tracks the Player object.
                Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction = target - myPos;
                // Used to rotate the Projectile in the correct position and shoot it in the correct direction.
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg + 90);
                GameObject projectile = Instantiate(leftFireball, wayPoint.transform.position, rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
                fireballCounter = !fireballCounter;
            }
        }
    }
}
