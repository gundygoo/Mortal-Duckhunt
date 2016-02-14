using UnityEngine;
using System.Collections;

public class ZapperScript : MonoBehaviour {

	public GameObject Zapper;
	public float timer;
	public Vector3 screenPosition;
	public int ZapperSpawnTime;

	
	// Use this for initialization
	void Awake () {
		ZapperSpawnTime = Random.Range(30, 45);
		timer = 60;
		screenPosition = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(4.50f, 5.0f), -1);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if ((int)timer == ZapperSpawnTime) {
			if (GameObject.Find ("amphora(Clone)") == null) {
				Instantiate (Zapper, screenPosition, Quaternion.identity);
				Destroy (gameObject);
			}
		}
	}
}
