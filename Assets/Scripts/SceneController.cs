using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    public float timer = 5;
    public int whichSpawn;
    public int levelCap = 10;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public float spearAccuracy;
    public int spearHit;
    public int normalAmountKilled;
    public int fastAmountKilled;
    public int slowAmountKilled;
    public int thrown;

    //public SpawnBirds spawner;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if (gameObject.GetComponent<Timer>().isPlayable)
        {
            if (timer <= 0)
            {
                //call the spawn function of a spawn gameobject
                whichSpawn = Random.Range(0, 3);

                //spawn a fast bird
                if (whichSpawn == 0)
                {
                    spawn1.GetComponent<SpawnBirds>().Spawn();
                }
                //spawn a normal bird
                if (whichSpawn == 1)
                {
                    spawn2.GetComponent<SpawnBirds>().Spawn();
                }
                //spawn a slow bird
                if (whichSpawn == 2)
                {
                    spawn3.GetComponent<SpawnBirds>().Spawn();
                }
                timer = 5;
            }
        }
    }

    public void TallyScore()
    {
        thrown = GameObject.Find("player_character").GetComponent<PlayerScript>().spearsThrown;
        spearAccuracy = (float)spearHit / (float)thrown * 100;
        print(GameObject.Find("player_character").GetComponent<PlayerScript>().spearsThrown);
        print(spearAccuracy + "%");
        print(normalAmountKilled);
        print(fastAmountKilled);
        print(slowAmountKilled);
    }
}
