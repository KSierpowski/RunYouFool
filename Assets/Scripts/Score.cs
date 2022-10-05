using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float scoreAmount = 0f;
    public float increasedPerSeconds = 5;

    void Update()
    {
        scoreText.text = (int)scoreAmount + " Points";
        scoreAmount += increasedPerSeconds * Time.deltaTime;
    }
}
