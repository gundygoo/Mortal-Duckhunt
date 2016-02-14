using UnityEngine;
using System.Collections;

public class DestroyScoreKeeper : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GameObject.Find("ScoreKeeper"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
