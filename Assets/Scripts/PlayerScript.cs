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
	private float throwCooldown = 0.5f;
    private float swingStart = 0f;
    private float swingEnd = 2.5f;
    public static bool isAnimated;
    public int spearsThrown;
    public AudioClip throwClip;
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

		// Flip the character when it is needed
		Vector3 flip = transform.localScale;
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		float WorldxPos = Camera.main.ScreenToWorldPoint(mousePosition).x;
		if (WorldxPos > gameObject.transform.position.x)
		{
			flip.x = -.75f;
			transform.localScale = flip;
		}
		else
		{
			flip.x = .75f;
			transform.localScale = flip;
		}

        // Throw spear after cooldown
		if(Input.GetMouseButtonDown(0) && Time.time > throwStart + throwCooldown)
        {
            // throw spear at position
            Instantiate(spear, transform.position, Quaternion.identity);
			throwStart = Time.time;
            spearsThrown++;
        }
        
        // Swing sword
        if (Input.GetMouseButtonDown(1)&& Time.time>swingStart+swingEnd)
        {
            isAnimated = true;
            animator.SetTrigger("sword_attack");
            swingStart = Time.time;
            isAnimated = false;
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
