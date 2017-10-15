using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    private float speed = 2.5f;
    // Finds the player object
	void Start () {
        wayPoint = GameObject.Find("some_kind_of_witch_thing");
	}
	
	// Update is called once per frame
	void Update () {
        // Takes the position and moves enemy character.
        Vector3 localPosition = wayPoint.transform.position - transform.position;
        localPosition = localPosition.normalized;
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
    }
}
