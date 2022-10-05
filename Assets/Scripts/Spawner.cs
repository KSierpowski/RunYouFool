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
        time = 0;
        Instantiate(spawnObject, transform.position, spawnObject.transform.rotation);
    }

    private void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

}

