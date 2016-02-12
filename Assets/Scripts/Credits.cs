using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    public GameObject gameCamera;
    public int speed = 1;
    public string level;
    public bool scrolling = true;
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(waitFor());
        //StartCoroutine(scrollTime());
        if (scrolling==true) {
            gameCamera.transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        StartCoroutine(waitFor());
        StartCoroutine(scrollTime());
        if (Input.anyKey)
        {
            Application.LoadLevel(level);
        }
	}

    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(45);
        Application.LoadLevel(level);
    }

    IEnumerator scrollTime()
    {
        yield return new WaitForSeconds(33);
        scrolling = false;
    }
}
