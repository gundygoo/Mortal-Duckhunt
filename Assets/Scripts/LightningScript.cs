using UnityEngine;
using System.Collections;

public class LightningScript : MonoBehaviour {

	public Renderer rend;
	public float lightningTimer = 0.2f;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	}
	// Update is called once per frame
	void Update () {
		lightningTimer -= Time.deltaTime;

		if (lightningTimer > 0) {
			rend.enabled = true;
		} else if (lightningTimer > -0.2f && lightningTimer <= 0) {
			rend.enabled = false;
		} else if (lightningTimer > -0.4f) {
			rend.enabled = true;
		} else
			Destroy (gameObject);
	}
}
