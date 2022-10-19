using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    public float speed = 1.0f;
    public float distancetoMove = 10f;
    public bool goForward = false;
    public Vector3 startPos;
    public Vector3 endPos;
    [SerializeField] LoadBall loadBall;
    Bonus bonus;

    private void Start()
    {
        bonus = loadBall.selectedPrefab.GetComponent<Bonus>();

        startPos = transform.position;

        MoveWalls();
        Invoke("ClampWalls", 10);
    }

    private void MoveWalls()
    {
        if (gameObject.name == "LeftWall")
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
        Invoke("BonusTrigger", 10);
    }
    private void BonusTrigger()
    {
        if (bonus.stopWalls == true)
        {
            
            ResetWalls();
        }
        else
        {
            ClampWalls();
        }

    }
    private void ClampWalls()
    {
        goForward = true;
        transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        
    }
    private void ResetWalls()
    {
        goForward = false;
        transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
    }
    
}
