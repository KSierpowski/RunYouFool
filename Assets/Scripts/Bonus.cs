using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class Bonus : MonoBehaviour
{   
    public bool isUntouchable = false;
    public bool isSpeed = false;
    public bool isSize = false;
    public bool stopWalls = false;
    public bool bonusLimit = false;
    public float bonusTime = 10f;
    public float currentSpeed = 0;
    public float speedMultiplier = 2f;
    public int catchedBonuses = 0;

    [SerializeField] Vector3 scaleVector;

    Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    private void Update()
    {
        BonusLimit();
    }

    public int IncreaseBonus()
    {
        return catchedBonuses;
    }
    public void BonusLimit()
    {
        if (IncreaseBonus() >= 20)
        {
            bonusLimit = true;
        }
        else bonusLimit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Immortale" && !bonusLimit)
        {
            catchedBonuses++;
            isUntouchable = true;
            StartCoroutine(Immortale());
        }
        if (other.gameObject.tag == "Speed" && !bonusLimit)
        {
            catchedBonuses++;
            isSpeed = true;
            StartCoroutine(Speed());
        }
        if (other.gameObject.tag == "Size")
        {
            catchedBonuses--;
            isSize = true;
            StartCoroutine(Size());
        }
        if (other.gameObject.tag == "StopWalls" && !bonusLimit)
        {
            catchedBonuses++;
            stopWalls = true;
            StartCoroutine(MovingWalls());
        }
    }

    private IEnumerator MovingWalls()
    {
        if(stopWalls)
        {
            yield return new WaitForSeconds(10f);
            stopWalls = false;

        }
    }
    private IEnumerator Size()
    {
        if(isSize)
        {
            transform.localScale += scaleVector;
            yield return new WaitForSeconds(bonusTime);
            isSize = false;
            transform.localScale -= scaleVector;
            yield return null;
        }
    }

    private IEnumerator Speed()
    {
        if(isSpeed)
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
        if(isUntouchable)
        {
            yield return new WaitForSeconds(bonusTime);
            isUntouchable = false;
            yield return null;
        }
    }
}
