using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Slider timerSlider;
    public float timer;
    public bool isPlayable = true;
    public GameObject curtain;

	// Use this for initialization
	void Start () {
    
        timer = 60;

    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        
        if(Application.loadedLevelName != "ScoreScene")
            timerSlider.value = timer;

        if(timer <= 0)
        {
            isPlayable = false;
            print("End game");
            /*if (Application.loadedLevelName == "Level1")
                Application.LoadLevel("Level1Poseidon");
            if (Application.loadedLevelName == "Level1Poseidon")
                Application.LoadLevel("Hades Level");*/
            //curtain.transform.position = Vector3.MoveTowards(curtain.transform.position, new Vector3(0, 0, -5), .5f);
            //before curtain is done moving, add score to scoreKeeper.
            //gameObject.GetComponent<ScoreKeeper>().ScoreTally();
            Application.LoadLevel(Application.loadedLevel + 1);
        }
	}
}
