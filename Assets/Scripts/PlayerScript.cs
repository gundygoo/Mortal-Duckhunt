using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public SceneController sceneController;
    public int playerHealth;
    public bool powerUp;
    public GameObject spearHand;
    public GameObject spear;
    //public GameObject player;
    //public GameObject swordHand;
    //static Vector3 mousePos = Input.mousePosition;
	
    // Use this for initialization
	void Start () {
        playerHealth = 100;
        powerUp = false;

	}
	
	// Update is called once per frame
	void Update () {
        //float mouseX = (Input.mousePosition.x);
        //float mouseY = (Input.mousePosition.y);
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));
        //print(mousePos);

        // Throw spear
        if(Input.GetMouseButtonDown(0))
        {
            //print("true");
            // throw spear at mouse position
            // get mouse position
            // throw spear at position
            //print position of mouse
            //float mouseX = (Input.mousePosition.x);
            //float mouseY = (Input.mousePosition.y);
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));
            //print(mousePos);
           
            //Vector3 mousePos = Input.mousePosition;
            //targetPos = 
            Instantiate(spear, transform.position, Quaternion.identity);
            //spear.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f));
        }
        /*
        // Swing sword
        if (Input.GetMouseButton(1))
        {
            // swing sword
        }

        // Use Zeus' lightning (powerup)
        if (Input.GetKeyDown("space")) //KeyCode.Space
        {
            // Create lighting
            // Defeat enemies on-screen
            //powerUp = false;
        }
         * */
	}
}
