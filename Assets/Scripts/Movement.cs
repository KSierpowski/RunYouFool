using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticle;

    public bool isCollision = false;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (bonus.isUntouchable == true) return;
            else
            { 
                StartCoroutine(EndGame());
                isCollision = true;
            }
        }
    }
    private IEnumerator EndGame()
    {
        explosionParticle.Play();
        GetComponent<Movement>().enabled = false;
        yield return new WaitForSeconds(1f);
        yield return null;

    }
    public float GetSpeed()
    {
        return bonus.currentSpeed;

    }
}