﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    public void LoadNextLevel()
    {
        int i = Application.loadedLevel;
        Application.LoadLevel(i + 1);
    }

    public void RestartGame()
    {
        Destroy(GameObject.Find("ScoreKeeper"));
        Application.LoadLevel(0);
    }
}
