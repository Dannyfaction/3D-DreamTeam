using UnityEngine;
using System.Collections;

public class WorldEventScript : MonoBehaviour {

    public GameObject event_1_Cam;

    //main camera
    [SerializeField]
    private GameObject playerCam;

    [SerializeField]
    private GameObject to_Text_1;
    [SerializeField]
    private GameObject to_Text_2;
    [SerializeField]
    private GameObject to_Text_3;

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
        //cameraEvents.IntersectionEvent();
        Destroy(GameObject.Find("Event_1"));
    }

    public void Event2()
    {
        Debug.Log("play 2");
    }


    //for Intro level events
    public void To_Event1()
    {
        to_Text_1.gameObject.SetActive(true);
        Invoke("removeObject",3f);
    }

    public void To_Event2()
    {
        to_Text_2.gameObject.SetActive(true);
        Invoke("removeObject", 3f);
    }

    public void To_Event3()
    {
        to_Text_3.gameObject.SetActive(true);
        Invoke("removeObject", 3f);
    }

    private void removeObject()
    {
        to_Text_1.gameObject.SetActive(false);
        to_Text_2.gameObject.SetActive(false);
        to_Text_3.gameObject.SetActive(false);
    }
}
