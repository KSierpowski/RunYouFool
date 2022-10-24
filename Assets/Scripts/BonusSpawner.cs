using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform[] spawnPoints;
    public List<GameObject> spawnedObjects; 

    public int spawnCount; 
    public float spawnTime;
    private int objectIndex; 
    private int spawnIndex;
    private void Start()
    {   
        StartCoroutine(RandomSpawn());
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            objectIndex = Random.Range(0, objectsToSpawn.Length);
            spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject spawn = Instantiate(objectsToSpawn[objectIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
            spawnedObjects.Add(spawn);
        }
    }
    IEnumerator RandomSpawn()
    {
        while(spawnCount > 0)
        {
            Spawn();
            yield return new WaitForSeconds(spawnTime);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Gizmos.DrawSphere(spawnPoints[i].position, 0.5f);
        }
    }
}
