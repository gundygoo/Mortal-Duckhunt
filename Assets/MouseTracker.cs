using UnityEngine;
using System.Collections;

public class MouseTracker : MonoBehaviour {
    public GameObject cursor;
    public Vector3 cursorPos;

	// Use this for initialization
	void Start () {
        //Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = -9;
        cursor.transform.position = cursorPos;
	}
}
