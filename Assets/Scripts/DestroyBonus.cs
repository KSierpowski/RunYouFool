using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBonus : MonoBehaviour
{
    public float lifeTime = 5f;
    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
