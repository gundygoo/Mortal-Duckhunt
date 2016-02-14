using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    private int healthStart = 20;
    private int healthCurrent;
    public Slider healthSlider;

    void Awake()
    {
        healthCurrent = healthStart;
    }

	// Use this for initialization
	void Start () {
        //print("health" + healthCurrent);
	}

    void Update()
    {
        
    }

    public void loseHealth(int damage)
    {
        healthCurrent -= damage;
        healthSlider.value = healthCurrent;
        print(healthCurrent);

        if (healthCurrent == 0f)
        {
            SceneManager.LoadScene("LoseScoreScene");
        }
    }

    void gainHealth()
    {
        healthCurrent += 3;
    }
}
