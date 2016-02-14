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
	public GameObject[] gameObjects;
	public GameObject score1000;
	public GameObject lightning;
	public Vector3 scorePosition;
	public Vector3 lightningPosition;
    //public GameObject swordHand;
    //static Vector3 mousePos = Input.mousePosition;

    void Awake()
    {
        animator = GetComponent<Animator>();
		scorePosition = new Vector3(0, 1.5f, -1);
		lightningPosition = new Vector3 (0, 0, 0);
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
            Instantiate(spear, transform.position + new Vector3(-.2f, .5f, -1f), Quaternion.identity);
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

		if (Input.GetKeyDown ("space") && powerUp == true) {
			DestroyAllBirds ();
			powerUp = false;
			GameObject.Find("SceneController").GetComponent<SceneController>().lightningKill++;
			GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>().AddToScore(1000);
			Instantiate(score1000, scorePosition, Quaternion.identity);
			Instantiate (lightning, lightningPosition, Quaternion.identity);
		}
	}

	void DestroyAllBirds()
	{
		gameObjects = GameObject.FindGameObjectsWithTag ("Bird");
		for(var i = 0; i < gameObjects.Length; i++)
			Destroy(gameObjects[i]);
	}

}