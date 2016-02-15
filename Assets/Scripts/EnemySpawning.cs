using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawning : MonoBehaviour {

    private List<GameObject> spawnPoints;
    private List<GameObject> enemiesToSpawn;
    [SerializeField] private float numberOfSpawns;
    [SerializeField] private float spawnDelay;

	void Start () {
        spawnPoints = new List<GameObject>();
        enemiesToSpawn = new List<GameObject>();
        enemiesToSpawn.Add(Resources.Load<GameObject>("EnemyGreyboxed"));
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints.Add(transform.Find("Spawnpoint"+i).gameObject);
        }
        for (int i = 0; i < numberOfSpawns; i++)
        {
            Invoke("Spawn",spawnDelay*i);
        }
	}

    public void Spawn()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Instantiate(enemiesToSpawn[0], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y+0.5f, spawnPoints[i].transform.position.z), Quaternion.identity);
        }
    }
}
