using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScore;
    [SerializeField] public float scoreAmount = 0f;
    [SerializeField] float increasedPerSeconds = 5;

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
        finalScore.text = scoreAmount.ToString("0");
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
