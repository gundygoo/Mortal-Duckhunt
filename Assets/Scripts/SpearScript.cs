using UnityEngine;
using System.Collections;

public class SpearScript : MonoBehaviour {
    public SceneController sceneController;
    //public int playerHealth;
    //public bool powerUp;
    //public GameObject spear;
    //public Transform target;
    //public GameObject target;
    public float speed = 4;
    public GameObject player;
    public Vector3 mousePos;
    private float delay;
    public GameObject spear;
    //public GameObject swordHand;
    //static Vector3 mousePos = Input.mousePosition;
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 9;
        //delay = 4;
        //Instantiate(spear, transform.position, Quaternion.identity);
        //transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);


    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = (Input.mousePosition.x);
        //float mouseY = (Input.mousePosition.y);
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));
        //print(mousePos);
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 playerPos = GameObject.Find("Player").transform.position;
        //spear.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f));
        transform.position = Vector3.MoveTowards(transform.position, 3*mousePos, speed);//speed * Time.deltaTime);

        delay += 1.0F * Time.deltaTime;

        WaitAndDestroy();
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        //print(transform.position);
        //Vector2 direction = target - playerPos;
        //transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);

    }

    void WaitAndDestroy()
    {
        if (delay >= 4)
        {
            GameObject.Destroy(gameObject);
        }
    }
}