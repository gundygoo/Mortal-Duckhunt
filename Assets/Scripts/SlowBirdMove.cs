using UnityEngine;
using System.Collections;

public class SlowBirdMove : MonoBehaviour {

    public Vector3 worldPos;
    public bool turnPoint = false;
    public float speed;
    public Vector3 flyToPosition;
    public Vector3 moveTo;
    public Health healthBar;
    public int health = 3;
    public int damage = 3;

    //public Vector3 targetPlayer = GameObject.FindWithTag("player_character").transform;

    // Use this for initialization
    void Awake()
    {
        Camera cam = Camera.main.GetComponent<Camera>();
        flyToPosition = new Vector3(Random.Range(0.2f, .8f), Random.Range(.5f, .8f), 1);
        worldPos = cam.ViewportToWorldPoint(flyToPosition);
        moveTo = new Vector3(worldPos.x, worldPos.y, -1);
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == moveTo)
        {
            turnPoint = true;
            speed = 1f;
        }

        if (!turnPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -2, -1), Time.deltaTime * speed);
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
            }

        }
        if (other.gameObject.tag == "Player")
        {
            if (turnPoint)
            {
                Destroy(gameObject);
                //healthBar.loseHealth(damage);
            }
        }
    }
}
