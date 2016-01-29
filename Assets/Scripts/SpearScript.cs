using UnityEngine;
using System.Collections;

public class SpearScript : MonoBehaviour {
    public SceneController sceneController;
    //public int playerHealth;
    //public bool powerUp;
    public GameObject spear;
    public Transform target;
    public float speed;
    //public GameObject player;
    //public GameObject swordHand;
    //static Vector3 mousePos = Input.mousePosition;

    // Update is called once per frame
    void Update()
    {
        float mouseX = (Input.mousePosition.x);
        float mouseY = (Input.mousePosition.y);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));
        print(mousePos);

        spear.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f));

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        print(transform.position);
    }
}