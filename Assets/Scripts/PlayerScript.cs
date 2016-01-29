using UnityEngine;
using System.Collections;

public class PlayerScipt : MonoBehaviour {
    public SceneController sceneController;
    public int playerHealth;
    public bool powerUp;
    
	
    // Use this for initialization
	void Start () {
        playerHealth = 100;
        powerUp = false;

	}
	
	// Update is called once per frame
	void Update () {
	    // Get mouse
        

        // Throw spear
        if(Input.GetMouseButton(0))
        {
            // throw spear at mouse position
            // get mouse position
            // throw spear at position
        }

        // Swing sword
        if (Input.GetMouseButton(1))
        {
            // swing
        }

        // Use Zeus' lightning (powerup)
        if (Input.GetKeyDown("space")) //KeyCode.Space
        {
            powerUp = false;
        }
	}
}
