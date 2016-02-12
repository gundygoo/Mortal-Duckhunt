using UnityEngine;
using System.Collections;

public class ZapperScript : MonoBehaviour {

	public GameObject Zapper;
	public float timer;
	public int ZapperSpawnTime = Random.Range(30, 45);
	Vector3 screenPosition;

	
	// Use this for initialization
	void Awake () {
		timer = 60;
		screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(Screen.width/3,2*Screen.width/3),Random.Range(6*Screen.height/4,2*Screen.height),9));
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if ((int)timer == ZapperSpawnTime) {
			if (GameObject.Find ("amphora(Clone)") == null) {
				Instantiate (Zapper, screenPosition ,Quaternion.identity);
			}
		}
	}
}
