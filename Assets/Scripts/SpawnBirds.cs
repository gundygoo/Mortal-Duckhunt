using UnityEngine;
using System.Collections;

public class SpawnBirds : MonoBehaviour {

    public int timer = 15;
    public GameObject bird;
    public GameObject spawnPoint;

	// Use this for initialization
	void Start () {
	    
	}
	
    void Spawn()
    {
        Instantiate(bird, transform.position, Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {
        timer -= 1;
        if (timer == 0)
        {
            Spawn();
            timer = 15;
        }
	}
}
