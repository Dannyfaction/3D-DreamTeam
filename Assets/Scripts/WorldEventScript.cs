using UnityEngine;
using System.Collections;

public class WorldEventScript : MonoBehaviour {

    public GameObject playerCam;
    public GameObject event_1_Cam;

    [SerializeField]
    private GameObject cameraObject;

    CameraEventScript cameraEvents;

    CameraScript camera;
	// Use this for initialization
	void Start () {
        camera = cameraObject.GetComponent<CameraScript>();
        cameraEvents = GameObject.Find("CameraEvent").GetComponent<CameraEventScript>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Event1()
    {
        Debug.Log("play 1");
        //switches camera
        playerCam.gameObject.SetActive(false);
        event_1_Cam.gameObject.SetActive(true);

        //start event
        cameraEvents.IntersectionEvent();
        Destroy(GameObject.Find("Event_1"));
    }

    public void Event2()
    {
        Debug.Log("play 2");
    }

    public void Event3()
    {
        Debug.Log("play 3");
    }
}
