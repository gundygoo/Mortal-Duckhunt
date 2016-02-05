using UnityEngine;
using System.Collections;

public class SpawnBirds : MonoBehaviour {

    public GameObject bird;
    public GameObject fastBird;
    public GameObject slowBird;
    private int birdType;

	// Use this for initialization
	void Start () {
	    
	}
	
    public void Spawn()
    {
        birdType = Random.Range(0, 3);

        //spawn a fast bird
        if(birdType == 0)
        {
            Instantiate(fastBird, transform.position, Quaternion.identity);
        }
        //spawn a normal bird
        if(birdType == 1)
        {
            Instantiate(bird, transform.position, Quaternion.identity);
        }
        //spawn a slow bird
        if(birdType == 2)
        {
            Instantiate(slowBird, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
