﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FastBirdMove : MonoBehaviour {

    public Vector3 worldPos;
    public bool turnPoint = false;
    public bool flyAway = false;
    public float speed;
    public Vector3 flyToPosition;
    public Vector3 moveTo;
    public int health = 1;
    public int damage = 1;
    public int fastBaseScore = 200;
    public GameObject score200;
    public GameObject score250;
    public GameObject player;
    public AudioSource source;
    public AudioClip clip;
    public AudioClip spearClip;
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
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == moveTo)
        {
            turnPoint = true;
            speed = 5f;
        }

        if (!turnPoint && !flyAway)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime * speed);
        }
        else if (turnPoint && !flyAway)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        }
         else if (turnPoint && flyAway)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
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
            source.PlayOneShot(spearClip);

            health -= 1;

            if (health == 0)
            {
                GameObject.Find("SceneController").GetComponent<AudioSource>().PlayOneShot(clip);
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
                //Destroy(gameObject);
                //healthBar.loseHealth(damage);
                other.gameObject.GetComponent<Health>().loseHealth(damage);
                other.GetComponent<AudioSource>().Play();
                flyAway = true;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                Destroy(gameObject, 3f);
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