using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    [SerializeField] private int whichCheckpoint;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerControl playerScript = collision.GetComponent<PlayerControl>();
            playerScript.CurrentCheckpoint = whichCheckpoint;
        }
    }
}
