using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 100f;

    public Rigidbody rb;


    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            rb.AddForce(-Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }


    }
}