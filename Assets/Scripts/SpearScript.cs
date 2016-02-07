using UnityEngine;
using System.Collections;

public class SpearScript : MonoBehaviour {
    public SceneController sceneController;
    //public int playerHealth;
    //public bool powerUp;
    //public GameObject spear;
    //public Transform target;
    //public GameObject target;
    public float speed = 2;
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

		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
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
        
		transform.position = Vector3.MoveTowards(transform.position, mousePos, speed);//speed * Time.deltaTime);

        delay += Time.deltaTime;

        WaitAndDestroy();
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        //print(transform.position);
        //Vector2 direction = target - playerPos;
        //transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);

    }

    void WaitAndDestroy()
    {
        if (delay >= 2)
        {
            GameObject.Destroy(gameObject);
        }
    }
}