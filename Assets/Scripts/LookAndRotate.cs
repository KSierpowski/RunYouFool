using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAndRotate : MonoBehaviour
{
    public Transform target;

    private void FixedUpdate()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.right * 10 * Time.deltaTime);
    }

}
