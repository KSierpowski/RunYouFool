using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPickup : MonoBehaviour
{

    public bool isUntouchable = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bonus")
        {
            isUntouchable = true;
        }
    }

}
