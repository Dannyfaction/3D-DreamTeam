using UnityEngine;
using System.Collections;

public class WorldEventScript : MonoBehaviour {

    public GameObject event_1_Cam;

    //main camera
    [SerializeField]
    private GameObject playerCam;

    CameraEventScript cameraEvents;

    CameraScript camera;
	// Use this for initialization
	void Start () {
        camera = playerCam.GetComponent<CameraScript>();
        cameraEvents = event_1_Cam.GetComponent<CameraEventScript>();
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
