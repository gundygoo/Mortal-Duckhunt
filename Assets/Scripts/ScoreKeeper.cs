using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public int score;
    public int normalBirdScore;
    public int fastBirdScore;
    public int slowBirdScore;
    public float hitAccuracy;
    public int spearHit;
    public int spearThrown;
    public Text normal;
    public Text fast;
    public Text slow;
    public Text accuracy;
    public Text levelScore;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
        if(GameObject.Find("SceneController"))
        {
            normalBirdScore = GameObject.Find("SceneController").GetComponent<SceneController>().normalAmountKilled;
            fastBirdScore = GameObject.Find("SceneController").GetComponent<SceneController>().fastAmountKilled;
            slowBirdScore = GameObject.Find("SceneController").GetComponent<SceneController>().slowAmountKilled;
            spearHit = GameObject.Find("SceneController").GetComponent<SceneController>().spearHit;
            spearThrown = GameObject.Find("player_character").GetComponent<PlayerScript>().spearsThrown;

            hitAccuracy = (float)spearHit / (float)spearThrown * 100;
        }

        if (Application.loadedLevelName == "ScoreScene")
        {
            normal = GameObject.Find("Normal Birds Hit Text").GetComponent<Text>();
            fast = GameObject.Find("Fast Birds Hit Text").GetComponent<Text>();
            slow = GameObject.Find("Slow Birds Hit Text").GetComponent<Text>();
            levelScore = GameObject.Find("ScoreText").GetComponent<Text>();
            accuracy = GameObject.Find("Spear Accuracy Text").GetComponent<Text>();
        }

        //if curtain is done moving
        /*if(gameObject.GetComponent<Timer>().curtain)
        {
            Application.LoadLevel("ScoreScene");
        }*/

        if(Application.loadedLevelName == "ScoreScene")
        {
            ScoreTally();
        }
	
	}

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void ScoreTally()
    {
        normal.text = normalBirdScore.ToString();
        fast.text = fastBirdScore.ToString();
        slow.text = slowBirdScore.ToString();
        levelScore.text = score.ToString();
        accuracy.text = (hitAccuracy.ToString() + "%");
    }
}
