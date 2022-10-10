using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bonus : MonoBehaviour
{   
    public bool isUntouchable = false;
    public bool isSpeed = false;
    public float currentSpeed = 0;
    public float speedMultiplier = 2f;

    Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Immortale")
        {
            isUntouchable = true;
            StartCoroutine(Immortale());
        }
        if (other.gameObject.name == "Speed")
        {
            isSpeed = true;
            StartCoroutine(Speed());
        }
    }

    private IEnumerator Speed()
    {
        currentSpeed = movement.GetSpeed() * speedMultiplier;
        yield return new WaitForSeconds(10f);
    }

    private IEnumerator Immortale()
    {
        if(isUntouchable == true)
        {
            yield return new WaitForSeconds(10f);
            isUntouchable = false;
            yield return null;
        }
    }
}
