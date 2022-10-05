using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;

    public float maxTime = 3;
    public float minTime = 1;
    private float time;
    private float spawnTime;
 
    private void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }

    }
    private void SpawnObject()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-23, 23), 35, 10); 
        time = 0;
        Instantiate(spawnObject, randomSpawnPosition, spawnObject.transform.rotation);
    }
    private void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

}

