using UnityEngine;
using System.Collections;

public class WorldEventCollision : MonoBehaviour {

    WorldEventScript worldEvents;

	// Use this for initialization
	void Start () {
        worldEvents = GameObject.Find("EventSystem").GetComponent<WorldEventScript>();
	}
	
	// Update is called once per frame
	void Update () {            
	}

    void onCollisionEnter(Collision coll)
    {
        if(coll.transform.name == "Event_1")
        {
            Debug.Log("hello");
            worldEvents.Event1();
        }

    }
}
