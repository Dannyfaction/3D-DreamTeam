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
            Debug.Log("help");
        }

        if (other.gameObject.name == "Event_2")
        {
            worldEvents.Event2();
        }

        if (other.gameObject.name == "Event_3")
        {
            worldEvents.Event3();
        }

        /* for the intro level if needed
        if (other.gameObject.name == "Event_3")
        {
            worldEvents.To_Event1();
        }

        //for intro level events
        if (other.gameObject.name == "To_Event_1")
        {
            worldEvents.To_Event1();
        }

        if (other.gameObject.name == "To_Event_2")
        {
            worldEvents.To_Event2();
        }

        if (other.gameObject.name == "To_Event_3")
        {
            worldEvents.To_Event3();
        }*/
    }
}
