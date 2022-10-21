using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaleChanger : MonoBehaviour
{
    Vector3 oldScale;
    public float speed = .15f;
    public float distanceToMove = -10;
    MovingWalls movingWalls;
    // Start is called before the first frame update
    void Start()
    {
        oldScale = new Vector3(57, 1, 75);
        movingWalls = GetComponent<MovingWalls>();
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundWall();
    }
    private void BackgroundWall()
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
