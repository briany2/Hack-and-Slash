﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This class is used to control the menu.
// Created by Brian Yu
public class MenuControl : MonoBehaviour {
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
