﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Slider timerSlider;
    public float timer;

	// Use this for initialization
	void Start () {
	    /*if(Application.loadedLevelName == "UIExperimentScene")
        {
            timer = 60;
        }*/
        timer = 60;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timerSlider.value = timer;

        if(timer == 0)
        {
            print("End game");
        }
	}
}