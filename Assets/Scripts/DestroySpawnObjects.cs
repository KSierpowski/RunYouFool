using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawnObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
