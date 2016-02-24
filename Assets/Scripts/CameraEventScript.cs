using UnityEngine;
using UnityEditor;
using System.Collections;

public class CameraEventScript : MonoBehaviour {

    private bool intersectionEvent = false;

    private float up = 0.01f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



        if (intersectionEvent) {

            int i = 0;
            if (i < 5 & this.transform.position.y < 40)
            {
                Time.timeScale = 0;
                transform.Translate(0, up, 0);
                i++;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
	}

    //For 360 rotation when ariving at the intersection
    public void IntersectionEvent() {
        intersectionEvent = true;
        Debug.Log("go rotate");
    }
}
