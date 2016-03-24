using UnityEngine;
using System.Collections;

public class CameraLerpedPos : MonoBehaviour {

    [SerializeField]
    private Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y+5f, target.position.z), 10f * Time.fixedDeltaTime);
    }
}
