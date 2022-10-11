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
    [SerializeField] Transform target;

    Bonus bonus;

    private void Start()
    {
        bonus = GameObject.FindWithTag("Player").GetComponent<Bonus>();
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
        BonusTrigger();
    }
    private void BonusTrigger()
    {
        if(bonus.stopWalls == true)
        {
            StopAllCoroutines();
        }
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
        if(bonus.stopWalls == false)
        {
            ClampWalls();
            for (int i = 0; i < Mathf.Infinity; i++)
            {
                yield return new WaitForSeconds(10f);
                goForward = true;
                yield return new WaitForSeconds(10f);
                goForward = false;
            }
        }

   
    }
}
