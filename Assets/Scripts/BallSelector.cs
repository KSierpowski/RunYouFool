using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSelector : MonoBehaviour
{
    public GameObject[] balls;
    public int selectedBall = 0;
    public TMP_Text nameText;

    private void Update()
    {
        nameText.text = balls[selectedBall].ToString();
    }

    public void NextChoice()
    {
        balls[selectedBall].SetActive(false);
        selectedBall = (selectedBall +1) % balls.Length;
        balls[selectedBall].SetActive(true);
    }
    public void PreviousChoise()
    {
        balls[selectedBall].SetActive(false);
        selectedBall--;
        if(selectedBall < 0)
        {
            selectedBall += balls.Length;
        }
        balls[selectedBall].SetActive(true);
    }
    public void StartGame(string levelName)
    {
        PlayerPrefs.SetInt("selectedBall", selectedBall);
        SceneManager.LoadScene(levelName);
    }
    
}
