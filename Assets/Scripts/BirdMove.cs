using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        //todo collision detecting and movement 

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="spearobjectname")
		{
			//fuse both objects and set gravity

			

			//negate the interaction with other objects (prevent it from damaging the player)
			// Right now it just destroys the spear, we'll do more later
			Destroy (gameObject);

			// Reduce spawners bird count
			GameObject Spawner = GameObject.Find("Spawn1");
			SpawnBirds spawnBirds = Spawner.GetComponent<SpawnBirds>();
			spawnBirds.birdCount-=1;
		}
	}
}
