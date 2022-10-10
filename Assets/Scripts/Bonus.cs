using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Bonus : MonoBehaviour
{
    public bool isUntouchable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Immortale")
        {
            isUntouchable = true;
            StartCoroutine(Immortale());
        }
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
