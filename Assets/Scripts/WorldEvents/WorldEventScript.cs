using UnityEngine;
using System.Collections;

public class WorldEventScript : MonoBehaviour {
    //main camera
    [SerializeField]
    private GameObject playerCam;

    CameraEventScript cameraEvents;

    CameraScript camera;
	// Use this for initialization
	void Start () {
        cameraEvents = GameObject.Find("WorldEventSystem").GetComponent<CameraEventScript>();
        camera = playerCam.GetComponent<CameraScript>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Event1()
    {
        Debug.Log("play 1");
        //switches camera
        cameraEvents.Event_1();

        //start event
        Destroy(GameObject.Find("Event_1"));
    }

    public void Event2()
    {
        cameraEvents.Event_2();
    }





    /* for into level if needed
    [SerializeField]
    private GameObject to_Text_1;
    [SerializeField]
    private GameObject to_Text_2;
    [SerializeField]
    private GameObject to_Text_3;

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
     */
}
