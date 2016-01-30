using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {

    public Vector3 worldPos;
    public bool turnPoint = false;
    public float speed;
    public Vector3 flyToPosition;

    // Use this for initialization
    void Awake() {
        Camera cam = Camera.main.GetComponent<Camera>();
        flyToPosition = new Vector3(Random.Range(0.2f, .8f), Random.Range(.5f, .8f), 1);
        worldPos = cam.ViewportToWorldPoint(flyToPosition);
        speed = 5f;
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position == worldPos)
        {
            turnPoint = true;
            speed = 3f;
        }

        if (!turnPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, worldPos, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -2, 0), Time.deltaTime * speed);
        }
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="spear(Clone)")
		{
			//fuse both objects and set gravity
			//negate the interaction with other objects (prevent it from damaging the player, reduce the number of remaining birds)
		}
	}
}
