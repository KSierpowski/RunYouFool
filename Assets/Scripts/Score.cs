using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float scoreAmount = 0f;
    public float increasedPerSeconds = 5;

    public bool countScore;
    GameOver gameOver;

    private void Start()
    {
        gameOver = GetComponent<GameOver>();
    }


    void Update()
    {
        StopCount();
        if (countScore)
        {
            CountScore();
        }
       
    }

    private void CountScore()
    {
        scoreAmount += increasedPerSeconds * Time.deltaTime;
        scoreText.text = scoreAmount.ToString("0");
    }
    private void StopCount()
    {
        if (gameOver.endGame == false)
        {
            countScore = true;
        }
        else { countScore = false; }
    }

}
