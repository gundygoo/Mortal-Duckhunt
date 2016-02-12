using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    public void LoadNextLevel()
    {
        int i = Application.loadedLevel;
        Application.LoadLevel(i + 1);
    }
}
