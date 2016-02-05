using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    public float timer = 5;
    public int whichSpawn;
    public int levelCap = 10;
    public float roundTimer = 60f;
    public GameObject spawn0;
    public GameObject spawn1;
    public GameObject spawn2;

    //public SpawnBirds spawner;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<Timer>().isPlayable)
        {
            if (timer <= 0)
            {
                //call the spawn function of a spawn gameobject
                whichSpawn = Random.Range(0, 3);

                //spawn a fast bird
                if (whichSpawn == 0)
                {
                    spawn0.GetComponent<SpawnBirds>().Spawn();
                }
                //spawn a normal bird
                if (whichSpawn == 1)
                {
                    spawn1.GetComponent<SpawnBirds>().Spawn();
                }
                //spawn a slow bird
                if (whichSpawn == 2)
                {
                    spawn2.GetComponent<SpawnBirds>().Spawn();
                }
                timer = 5;
            }
        }
    }
}
