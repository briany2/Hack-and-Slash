<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class allows an enemy to be damaged
// Created by Brian Yu
public class DamageEnemy : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
            ScoreManager.score++;
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
		{
			Destroy (gameObject);
			collider.gameObject.SendMessage ("TakeDamage", 25);
        }
    }
}
>>>>>>> b1b7578dd45b373b60561e74102a0e834ebf5a35
