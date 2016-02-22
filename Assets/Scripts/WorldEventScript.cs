using UnityEngine;
using System.Collections;

public class WorldEventScript : MonoBehaviour {

    [SerializeField]
    private GameObject cameraObject;

    CameraScript camera;
	// Use this for initialization
	void Start () {
        camera = cameraObject.GetComponent<CameraScript>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Event1()
    {
        Debug.Log("play 1");
        camera.DeathCamera();
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
