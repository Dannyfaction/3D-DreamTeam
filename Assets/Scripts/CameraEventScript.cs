using UnityEngine;
using UnityEditor;
using System.Collections;

public class CameraEventScript : MonoBehaviour {

    public GameObject event_1_Cam;

    //main camera
    [SerializeField]
    private GameObject playerCam;


    private bool intersectionEvent = false;

    private float up = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



        if (intersectionEvent) {
            int i = 0;
            if (i < 6 & transform.position.y < 40)
            {
                Debug.Log("doet ie het?");
                transform.Translate(0, up, 3);
                i++;
                Time.timeScale = 0;
            }
            else {
                intersectionEvent = false;

                playerCam.gameObject.SetActive(true);
                event_1_Cam.gameObject.SetActive(false);

                Time.timeScale = 1;
            }
        }
	}

    //For 360 rotation when ariving at the intersection
    public void IntersectionEvent() {
        intersectionEvent = true;
        Debug.Log(intersectionEvent);
    }
}
