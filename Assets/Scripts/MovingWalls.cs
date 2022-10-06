using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    public float speed = 1.0f;
    public float distancetoMove = 10f;
    public bool goForward=false;
    public Vector3 startPos;
    public Vector3 endPos;
    [SerializeField] Transform target;
    public GameObject player;
    private void Start()
    {
        startPos = transform.position;

        if(gameObject.name == "LeftWall")
        {
            endPos = transform.position - Vector3.left * distancetoMove;
        }
        if (gameObject.name == "RightWall")
        {
            endPos = transform.position - Vector3.right * distancetoMove;
        }
        
    }
    void Update()
    {
        StartCoroutine(MoveWall());
    }

    private void ClampWalls()
    {
        if (goForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
    }
    private IEnumerator MoveWall()
    { 
        //todo do until player is alive
            ClampWalls();
            yield return new WaitForSeconds(30f);
            goForward = true;
            yield return new WaitForSeconds(15f);
            goForward = false;

    }
}
