using UnityEngine;
using System.Collections;

public class SpawnBirds : MonoBehaviour {

    public float timer =  5;
    public GameObject bird;
    public int birdCount = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
    void Spawn()
    {
        Instantiate(bird, transform.position, Quaternion.identity);
        birdCount += 1;
    }

	// Update is called once per frame
	void Update () {
        if (birdCount < 10)
        {
            timer -= Time.deltaTime;
        }
        
        if (timer <= 0)
        {
            if (birdCount < 10)
            {
                Spawn();
                timer = 10;
            }
        }
	}
}
