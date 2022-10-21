using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public int winGameBonusAmount = 50;
    private bool isFinish = false;
    [SerializeField] Canvas winGameCanv;
    [SerializeField] Canvas endGameCanvas;
    [SerializeField] GameObject obstacleSpawn;
    [SerializeField] GameObject bonusSpawner;
    [SerializeField] Movement movement;
    [SerializeField] LoadBall loadBall;

    Bonus bonus;
    void Start()
    {
        movement = loadBall.selectedPrefab.GetComponent<Movement>();
        bonus = loadBall.selectedPrefab.GetComponent<Bonus>();
        winGameCanv.enabled = false;
        endGameCanvas.enabled = false;  
    }

    void Update()
    {
        LostGame();
        WinGame();
    }
    private void WinGame()
    {
        if (bonus.IncreaseBonus() == winGameBonusAmount)
        {
            isFinish = true;
            winGameCanv.enabled = true;
            movement.enabled = false;
            bonus.enabled = false;
            obstacleSpawn.SetActive(false);
            bonusSpawner.SetActive(false);
        }
    }
    private void LostGame()
    {
        if(movement.isCollision && !isFinish) 
        {
            endGameCanvas.enabled = true;
        }
    }

}
