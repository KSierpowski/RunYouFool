using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{

    Bonus bonus;
    public Rigidbody rb;

    private void Start()
    {
        bonus = GetComponent<Bonus>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            rb.AddForce(-Vector3.right * GetSpeed() * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector3.right * GetSpeed() * Time.deltaTime);
        }
    }
    public float GetSpeed()
    {
        return bonus.currentSpeed;

    }
}