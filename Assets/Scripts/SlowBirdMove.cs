using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlowBirdMove : MonoBehaviour {

    public Vector3 worldPos;
    public bool turnPoint = false;
    public bool flyAway = false;
    public float speed;
    public Vector3 flyToPosition;
    public Vector3 moveTo;
    public int health = 3;
    public int damage = 3;
    public int slowBaseScore = 300;
    public GameObject score300;
    public GameObject score350;
    public GameObject player;
    //public Vector3 targetPlayer = GameObject.FindWithTag("player_character").transform;

    // Use this for initialization
    void Awake()
    {
        Camera cam = Camera.main.GetComponent<Camera>();
        flyToPosition = new Vector3(Random.Range(0.2f, .8f), Random.Range(.7f, .9f), -1);
        worldPos = cam.ViewportToWorldPoint(flyToPosition);
        moveTo = new Vector3(worldPos.x, worldPos.y, -1);
        speed = 3f;
        player = GameObject.Find("player_character");
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == moveTo)
        {
            turnPoint = true;
            speed = 1f;
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

            health -= 1;

            if (health == 0)
            {
                Destroy(gameObject);
                OnDestroyScore();
                GameObject.Find("SceneController").GetComponent<SceneController>().slowAmountKilled++;
                GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().AddToScore(slowBaseScore);

            }

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
                flyAway = true;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                Destroy(gameObject, 3f);
                //health.loseHealth(5);
            }
        }

        if (other.gameObject.tag == "Sword")
        {
            slowBaseScore += 50;
            Destroy(gameObject);
            OnDestroyScore();
            GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().AddToScore(slowBaseScore);
        }
    }

    void OnDestroyScore()
    {
        if (slowBaseScore == 300)
        {
            Instantiate(score300, transform.position, Quaternion.identity);
            
        }
        else
        {
            Instantiate(score350, transform.position, Quaternion.identity);
            
        }

        //scoreText.text = slowBaseScore.ToString();
        //Instantiate(scoreText, transform.position, Quaternion.identity);
        //Destroy(scoreText, 1.0f);
    }
}
