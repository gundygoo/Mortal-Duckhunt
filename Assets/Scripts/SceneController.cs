using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    public float timer;
    public int whichSpawn;
    public int levelCap = 10;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public float spearAccuracy;
    public int spearHit;
    public int normalAmountKilled;
    public int fastAmountKilled;
    public int slowAmountKilled;
    public int thrown;
	public int lightningKill;

    //public SpawnBirds spawner;

    // Use this for initialization
    void Start () {
        SceneTimer();

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

                //spawn at spawn 1
                if (whichSpawn == 0)
                {
                    spawn1.GetComponent<SpawnBirds>().Spawn();
                }
                //spawn at spawn2
                if (whichSpawn == 1)
                {
                    spawn2.GetComponent<SpawnBirds>().Spawn();
                }
            
                //spawn at spawn 3
                if (whichSpawn == 2)
                {
                    spawn3.GetComponent<SpawnBirds>().Spawn();
                }
                //spawn at spawn 4
                if (whichSpawn == 3)
                {
                    spawn4.GetComponent<SpawnBirds>().Spawn();
                }
                SceneTimer();                
            }
        }
    }
    public void SceneTimer()
    {
        if(SceneManager.GetActiveScene().name=="Level1")
        {
            timer = Random.Range(2.0f, 5.0f);
        }
        if (SceneManager.GetActiveScene().name == "Level1Poseidon")
        {
            timer = Random.Range(1.5f, 4.0f);
        }
        if (SceneManager.GetActiveScene().name == "LevelZeus")
        {
            timer = Random.Range(1.0f, 3.0f);

        }
        if (SceneManager.GetActiveScene().name == "Hades Level")
        {
            timer = Random.Range(0.5f, 2.0f);

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
