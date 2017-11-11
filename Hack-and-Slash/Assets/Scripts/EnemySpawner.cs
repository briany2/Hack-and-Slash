using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // This code is used to spawn enemies at random positions a set distance away from the player.
    // Created by Brian Yu
    // Maybe use this line when instantiating other enemies.
    // public GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
    public GameObject frog, wayPoint;
    float rand;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    // Use this for initialization
    void Start()
    {
        wayPoint = GameObject.FindGameObjectWithTag("Player");
        frog = (GameObject)Instantiate(Resources.Load("FrogEnemy"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            rand = Random.Range(5f, 10f);
            int dir = Random.Range(0,4);
            if (dir == 0)
            {
                whereToSpawn = new Vector2(wayPoint.transform.position.x + rand, transform.transform.position.y + rand);
            } else if (dir == 1)
            {
                whereToSpawn = new Vector2(wayPoint.transform.position.x - rand, transform.transform.position.y + rand);
            } else if (dir == 2)
            {
                whereToSpawn = new Vector2(wayPoint.transform.position.x + rand, transform.transform.position.y - rand);
            } else
            {
                whereToSpawn = new Vector2(wayPoint.transform.position.x - rand, transform.transform.position.y - rand);
            }
            Instantiate(frog, whereToSpawn, Quaternion.identity);
        }
    }
}