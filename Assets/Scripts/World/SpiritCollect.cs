using UnityEngine;
using System.Collections;

public class SpiritCollect : MonoBehaviour {

    private float yValue = 0;
    private GameObject player;
    private float speed = 3f;
    private bool reachedTop = false;

    void Start()
    {
        player = GameObject.Find("N_ThirdPersonPlayer");
    }

    void Update() {
        if (transform.position.y < 8f && !reachedTop)
        {
            yValue += 4 * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
        }
        else
        {
            float distanceToTarget = Vector3.Distance(transform.position,new Vector3(player.transform.position.x, player.transform.position.y + 6.5f, player.transform.position.z));
            reachedTop = true;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,player.transform.position.y+6.5f,player.transform.position.z), step);
            if (distanceToTarget < 0.5f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
