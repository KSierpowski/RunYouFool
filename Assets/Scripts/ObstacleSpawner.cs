using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject spawnObject;

    public float maxTime = 3;
    public float minTime = 1;
    private float time;
    private float spawnTime;
    private float spawnFactor = 0.05f;
    public float minLimit = 0.3f;
    public float maxLimit = 0.5f;
    MovingWalls walls;

    private void Start()
    {
        walls = GetComponent<MovingWalls>();
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
        if (!walls.goForward)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-23, 23), 35, -4f);
            time = 0;
            Instantiate(spawnObject, randomSpawnPosition, spawnObject.transform.rotation);
        }
        else
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-11, 11), 35, -4f);
            time = 0;
            Instantiate(spawnObject, randomSpawnPosition, spawnObject.transform.rotation);
        }
        

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

