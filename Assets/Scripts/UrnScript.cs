using UnityEngine;
using System.Collections;

public class UrnScript : MonoBehaviour {


	private float delay;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		delay += Time.deltaTime;
		WaitAndDestroy ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Spear") {
			Destroy(other.gameObject);
			Destroy (gameObject);
			GameObject.Find ("player_character").GetComponent<PlayerScript> ().powerUp = true;
			print ("PowerUp status is: " + GameObject.Find ("player_character").GetComponent<PlayerScript> ().powerUp);
		}

		if (other.gameObject.tag == "Sword") {
			Destroy (gameObject);
			GameObject.Find ("player_character").GetComponent<PlayerScript> ().powerUp = true;
			print ("PowerUp status is: " + GameObject.Find ("player_character").GetComponent<PlayerScript> ().powerUp);
		}
	}
	void WaitAndDestroy()
	{
		if (delay >= 2)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
