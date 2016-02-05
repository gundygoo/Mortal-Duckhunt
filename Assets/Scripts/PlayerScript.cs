using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public SceneController sceneController;
    public int playerHealth;
    public bool powerUp;
    public GameObject spearHand;
    public GameObject spear;
    public Animator animator;
	private float throwStart = 0f;
	private float throwCooldown = 1f;
    //public GameObject swordHand;
    //static Vector3 mousePos = Input.mousePosition;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
	void Start () {
        playerHealth = 100;
        powerUp = false;
	}
	
	// Update is called once per frame
	void Update () {
        // Throw spear after cooldown
		if(Input.GetMouseButtonDown(0) && Time.time > throwStart + throwCooldown)
        {
            // throw spear at position
            Instantiate(spear, transform.position, Quaternion.identity);
			throwStart = Time.time;
        }
        
        // Swing sword
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("sword_attack");
        }

        /*
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
