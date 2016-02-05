﻿using UnityEngine;
using System.Collections;

public class RotateSper : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
	}
	
	// Update is called once per frame
	void Update () {
       
	
	}
}
