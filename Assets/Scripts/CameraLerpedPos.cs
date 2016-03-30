using UnityEngine;
using System.Collections;

public class CameraLerpedPos : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField] private float camSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y+7.5f, target.position.z), camSpeed * Time.fixedDeltaTime);
    }
}
