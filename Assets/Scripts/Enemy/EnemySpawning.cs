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

        //The Enemy Prefab in the Resources folder
        enemiesToSpawn.Add(Resources.Load<GameObject>("Enemy 1"));

        for (int i = 0; i < transform.childCount; i++)
        {
            //Puts all the current Spawnpoints in the map into a List
            spawnPoints.Add(transform.Find("Spawnpoint"+i).gameObject);
        }
        for (int i = 0; i < numberOfSpawns; i++)
        {
            //Makes the enemies spawn with an optional Delay
            Invoke("Spawn",spawnDelay*i);
        }
	}

    public void Spawn()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            //Spawns the Enemies and sends which Spawnpoint it spawned on to the Enemy script
            GameObject spawnedEnemy = (GameObject)Instantiate(enemiesToSpawn[0], new Vector3(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y+0.5f, spawnPoints[i].transform.position.z), Quaternion.Euler(0, 180f, 0));
            Enemy spawnedEnemyScript = spawnedEnemy.GetComponentInChildren<Enemy>();
            spawnedEnemyScript.whichSpawnpointSetter(i);
        }
    }
}
