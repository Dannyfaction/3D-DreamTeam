using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

    [SerializeField] private Character playerScript;
    [SerializeField] private GameObject healthObject;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float health = playerScript.Health;
        if (healthObject.transform.localScale.x > 0)
        {
            healthObject.transform.localScale = new Vector3((health / 100), 1, 1);
        }
    }
}
