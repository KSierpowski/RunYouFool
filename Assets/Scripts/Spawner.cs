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
    private float spawnFactor = 0.05f;
    public float minLimit = 0.3f;
    public float maxLimit = 0.5f;


    private void Start()
    { 
        SetRandomTime();
    }
    private void Update()
    {
        Invoke("ChangeSpawnTime", 5);
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
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-23, 23), 35, -2.5f); 
        time = 0;
        Instantiate(spawnObject, randomSpawnPosition, spawnObject.transform.rotation);
    }
    private void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        
    }
    private void ChangeSpawnTime()
    {
        if (minTime >= minLimit)
        {
            minTime -= spawnFactor * Time.deltaTime;
        }
        else if (maxTime >= maxLimit)
        {
            maxTime -= spawnFactor * Time.deltaTime;
        }
        else return;
    }

}

