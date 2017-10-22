using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 4f;
    public float timer = 0f;
    public float cooldown = 2.0f;
    public GameObject leftFireball, rightFireball, rFireball;
    public GameObject wayPoint;

	// Use this for initialization
	void Start () {
        wayPoint = GameObject.Find("some_kind_of_witch_thing");
    }

    // Update is called once per frame
    void FixedUpdate () {
        timer += Time.deltaTime;
        // Moves Character Left-Right
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.smoothDeltaTime, 0f, 0f));
        }
        // Moves Character Up-Down
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.smoothDeltaTime, 0f));
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            FireLeft();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            FireRight();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg + 90);
            GameObject projectile = Instantiate(leftFireball, wayPoint.transform.position, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
    
    void FireLeft()
    {   
        Instantiate(leftFireball, wayPoint.transform.position, Quaternion.identity);
    }

    void FireRight()
    {
        Instantiate(rightFireball, wayPoint.transform.position, Quaternion.identity);
    }
}
