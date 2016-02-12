using UnityEngine;
using System.Collections;

public class SpearScript : MonoBehaviour {
    public SceneController sceneController;
    public float speed = 2;
    public GameObject player;
    public Vector3 mousePos;
    private float delay;
    public GameObject spear;
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 9;

		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(.5f, 0, 0);

        delay += Time.deltaTime;

        WaitAndDestroy();
    }

    void WaitAndDestroy()
    {
        if (delay >= 2)
        {
            GameObject.Destroy(gameObject);
        }
    }
}