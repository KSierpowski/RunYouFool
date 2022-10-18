using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public int winGameBonusAmount = 50;
    [SerializeField] Canvas winGameCanv;
    [SerializeField] Canvas endGameCanvas;
    Bonus bonus;
    [SerializeField] Movement movement;
    [SerializeField] LoadBall loadBall;

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
            winGameCanv.enabled = true;
        }
    }
    private void LostGame()
    {
        if(movement.isCollision) 
        {
            endGameCanvas.enabled = true;
        }
    }

}
