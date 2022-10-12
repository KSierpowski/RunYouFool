using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bonus : MonoBehaviour
{   
    public bool isUntouchable = false;
    public bool isSpeed = false;
    public bool isSize = false;
    public bool stopWalls = false;
    public float bonusTime = 10f;
    public float currentSpeed = 0;
    public float speedMultiplier = 2f;

    Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Immortale")
        {
            isUntouchable = true;
            StartCoroutine(Immortale());
        }
        if (other.gameObject.tag == "Speed")
        {
            isSpeed = true;
            StartCoroutine(Speed());
        }
        if (other.gameObject.tag == "Size")
        {
            isSize = true;
            StartCoroutine(Size());
        }
        if (other.gameObject.tag == "StopWalls")
        {
            stopWalls = true;
            StartCoroutine(MovingWalls());
        }
    }

    private IEnumerator MovingWalls()
    {
        if(stopWalls == true)
        {
            yield return new WaitForSeconds(10f);
            stopWalls = false;

        }
    }
    private IEnumerator Size()
    {
        if(isSize == true)
        {
            transform.localScale += new Vector3(2, 2, 2);
            yield return new WaitForSeconds(bonusTime);
            isSize = false;
            transform.localScale -= new Vector3(2, 2, 2);
            yield return null;
        }
    }

    private IEnumerator Speed()
    {
        if(isSpeed == true)
        {
            currentSpeed = movement.GetSpeed() * speedMultiplier;
            yield return new WaitForSeconds(bonusTime);
            currentSpeed = movement.GetSpeed() / speedMultiplier;
            isSpeed = false;
            yield return null;
        }

    }

    private IEnumerator Immortale()
    {
        if(isUntouchable == true)
        {
            yield return new WaitForSeconds(bonusTime);
            isUntouchable = false;
            yield return null;
        }
    }
}
