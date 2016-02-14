using UnityEngine;
using System.Collections;

public class LightningBarScript : MonoBehaviour {

	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("PlayerScript").GetComponent<PlayerScript>().powerUp == true)
			rend.enabled = true;
		else
		{
			rend.enabled = false;
		}
	}
}
