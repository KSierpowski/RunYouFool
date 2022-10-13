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

    [SerializeField] TextMeshProUGUI bonusAmountText;

    public bool countScore;
    Movement movement;
    Bonus bonus;

    private void Start()
    {
        bonus = GameObject.FindWithTag("Player").GetComponent<Bonus>();
        movement = GameObject.FindWithTag("Player").GetComponent<Movement>();
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
        bonusAmountText.text = bonus.IncreaseBonus().ToString();
    }
    private void StopCount()
    {
        if (movement.isCollision == false)
        {
            countScore = true;
        }
        else { countScore = false; }
    }

}
