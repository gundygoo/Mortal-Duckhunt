using UnityEngine;
using System.Collections;

public class UrnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Spear") {
			Destroy(other.gameObject);
			Destroy (gameObject);
			GameObject.Find ("player_character").GetComponent<PlayerScript> ().powerUp = true;
			print ("PowerUp status is: " + GameObject.Find ("player_character").GetComponent<PlayerScript> ().powerUp);
		}
	}
}
