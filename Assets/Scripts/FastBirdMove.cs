﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FastBirdMove : MonoBehaviour {

    public Vector3 worldPos;
    public bool turnPoint = false;
    public float speed;
    public Vector3 flyToPosition;
    public Vector3 moveTo;
    public int health = 1;
    public int damage = 1;
    public int fastBaseScore = 200;
    public GameObject score200;
    public GameObject score250;
    public GameObject player;
    //public Vector3 targetPlayer = GameObject.FindWithTag("player_character").transform;

    // Use this for initialization
    void Awake()
    {
        Camera cam = Camera.main.GetComponent<Camera>();
        flyToPosition = new Vector3(Random.Range(0.2f, .8f), Random.Range(.5f, .8f), -1);
        worldPos = cam.ViewportToWorldPoint(flyToPosition);
        moveTo = new Vector3(worldPos.x, worldPos.y, -1);
        speed = 7f;
        player = GameObject.Find("player_character");
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == moveTo)
        {
            turnPoint = true;
            speed = 5f;
        }

        if (!turnPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spear")
        {
            //fuse both objects and set gravity
            //negate the interaction with other objects (prevent it from damaging the player, reduce the number of remaining birds)

            //negate the interaction with other objects (prevent it from damaging the player)
            // Right now it just destroys the spear, we'll do more later

            Destroy(other.gameObject);

            health -= 1;

            if (health == 0)
            {
                OnDestroyScore();
                Destroy(gameObject);
                GameObject.Find("SceneController").GetComponent<SceneController>().fastAmountKilled++;
                GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().AddToScore(fastBaseScore);
            }

            //controller.spearhit
            GameObject.Find("SceneController").GetComponent<SceneController>().spearHit++;

            // Reduce spawners bird count
            /*GameObject Spawner = GameObject.Find("Spawn1");
			SpawnBirds spawnBirds = Spawner.GetComponent<SpawnBirds>();
			SpawnBirds.birdCount-=1;*/

        }
        if (other.gameObject.tag == "Player")
        {
            if (turnPoint)
            {
                Destroy(gameObject);
                //healthBar.loseHealth(damage);
                other.gameObject.GetComponent<Health>().loseHealth(damage);
                //health.loseHealth(5);
            }
        }

        if (other.gameObject.tag == "Sword")
        {
            fastBaseScore += 50;
            Destroy(gameObject);
            OnDestroyScore();
            GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().AddToScore(fastBaseScore);
        }
    }

    void OnDestroyScore()
    {
        if (fastBaseScore == 200)
        {
            Instantiate(score200, transform.position, Quaternion.identity);
            
        }
        else
        {
            Instantiate(score250, transform.position, Quaternion.identity);
           
        }
    }
}