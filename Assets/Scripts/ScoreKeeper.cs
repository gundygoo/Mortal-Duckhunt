using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
    public int score;
    public int normalBirdScore;
    public int fastBirdScore;
    public int slowBirdScore;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
