using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadBall : MonoBehaviour
{
    public GameObject[] ballPrefab;
    public Transform spawnPoint;
    public GameObject selectedPrefab;

    void Awake()
    {
        int selectedBall = PlayerPrefs.GetInt("selectedBall");
        GameObject prefab = ballPrefab[selectedBall];
        
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        selectedPrefab = clone;
    }


}
