using UnityEngine;
using System.Collections;

public class WorldEventScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Event1()
    {
        Debug.Log("play 1");

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
