using UnityEngine;
using System.Collections;

public class FlippingCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 flip = transform.localScale;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        float WorldxPos = Camera.main.ScreenToWorldPoint(mousePosition).x;
        if (WorldxPos > gameObject.transform.position.x)
        {
            flip.x = -1;
            transform.localScale = flip;
        }
        else
        {
            flip.x = 1;
            transform.localScale = flip;
        }

    }
    
}
