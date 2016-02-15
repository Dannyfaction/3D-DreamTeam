using UnityEngine;
using UnityEditor;
using System.Collections;

public class CutScene : MonoBehaviour {

    [SerializeField]
    private Transform playPoint;
    private Transform backPoint;

    private float camSpeed;

	// Use this for initialization
	void Start () {
        //camera = GameObject.Find("camera");
        backPoint = transform;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision col)
    { 
        if(col.gameObject.tag == "cutSceneTag")
        {
            Debug.Log("cutscenes start");
            Debug.Log(backPoint);
            transform.position = Vector3.MoveTowards(playPoint.position, playPoint.position, Time.deltaTime);
        }
    }
}
