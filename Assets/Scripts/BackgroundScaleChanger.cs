using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaleChanger : MonoBehaviour
{
    Vector3 oldScale;
    public float speed = .15f;
    public float distanceToMove = -10;
    MovingWalls movingWalls;
    void Start()
    {
        oldScale = new Vector3(57, 1, 75);
        movingWalls = GetComponent<MovingWalls>();
    }

    void Update()
    {
        BackgroundWall();
    }
    private void BackgroundWall() //Change the scale of the background wall to match the position to the walls
    {
        if (movingWalls.goForward)
        {
            var newScale = new Vector3(distanceToMove, 1, 75);
            transform.localScale = Vector3.Lerp(transform.localScale, newScale, speed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, oldScale, speed * Time.deltaTime);
        }

    }
}
