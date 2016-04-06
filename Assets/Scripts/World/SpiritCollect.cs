using UnityEngine;
using System.Collections;

public class SpiritCollect : MonoBehaviour {

    private float yValue;
    private float initialYpos;
    private GameObject player;
    private float speed = 3f;
    private bool reachedTop = false;
    private ParticleSystem[] particleSystems;
    private bool isDestroyed = false;

    void Start()
    {
        player = GameObject.Find("N_ThirdPersonPlayer");
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        yValue = transform.position.y;
        initialYpos = transform.position.y + 8f;
    }

    void Update() {
        if (speed < 25f)
        {
            speed += 0.1f;
        }
        if (transform.position.y < initialYpos && !reachedTop)
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
            if (distanceToTarget < 0.5f && !isDestroyed)
            {
                particleSystems[0].Stop();
                particleSystems[1].Stop();
                particleSystems[3].Play();
                Destroy(transform.Find("ENEMY Spirit Ball Shine").gameObject);
                Destroy(transform.Find("Point light").gameObject);
                Invoke("DestroyObject",3f);
                isDestroyed = true;
            }
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
