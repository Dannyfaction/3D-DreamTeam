using UnityEngine;
using System.Collections;

public class WorldEventCollision : MonoBehaviour {

    WorldEventScript worldEvents;

	// Use this for initialization
	void Start () {
        worldEvents = GameObject.Find("WorldEventSystem").GetComponent<WorldEventScript>();
	}
	
	// Update is called once per frame
	void Update () {            
	}

    void OnTriggerEnter(Collider other)
    {
        //for ingame events
        if(other.gameObject.name == "Event_1")
        {
            worldEvents.Event1();
        }

        if (other.gameObject.name == "Event_2")
        {
            worldEvents.Event2();
        }

        if (other.gameObject.name == "Event_3")
        {
            worldEvents.Event3();
        }
    }
}
