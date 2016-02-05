﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    private int healthStart = 20;
    private int healthCurrent;
    public Slider healthSlider;

    void Awake()
    {
        healthCurrent = healthStart;
    }

	// Use this for initialization
	void Start () {
        print("health" + healthCurrent);
	}

    public void loseHealth(int damage)
    {
        healthCurrent -= damage;
        healthSlider.value = healthCurrent;
        print(healthCurrent);

        /*
        if(dead)
        {
            dead
        }
        */
    }

    void gainHealth()
    {
        healthCurrent += 3;
    }
}