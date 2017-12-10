using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // This code is used to spawn enemies at random positions a set distance away from the player.
    // Created by Brian Yu
    // Maybe use this line when instantiating other enemies.
    // public GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
    public GameObject frog, eyeball, wayPoint;
    float rand;
    Vector2 whereToSpawn;
    public float spawnRate = 3f;
    float nextSpawn = 1f;

    // Use this for initialization
    void Start()
    {
        wayPoint = GameObject.FindGameObjectWithTag("Player");
        frog = (GameObject)Instantiate(Resources.Load("FrogEnemy"));
		eyeball = (GameObject)Instantiate (Resources.Load ("EyeballEnemy"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
			int enemyType = Random.Range (0, 4);
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
			if (enemyType >= 2) {
				Instantiate (eyeball, whereToSpawn, Quaternion.identity);
			} else {
				Instantiate (frog, whereToSpawn, Quaternion.identity);
			}
        }
    }
}