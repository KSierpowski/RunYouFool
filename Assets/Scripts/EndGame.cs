using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public int winGameBonusAmount = 50;
    public int winGameScoreAmount = 1000;
    public bool isFinish = false;

    [SerializeField] Canvas winGameCanv;
    [SerializeField] Canvas endGameCanvas;
    [SerializeField] GameObject obstacleSpawn;
    [SerializeField] GameObject bonusSpawner;
    [SerializeField] Movement movement;
    [SerializeField] LoadBall loadBall;
    [SerializeField] AudioClip victory;

    AudioSource audioSource;
    Bonus bonus;
    Score score;

    void Start()
    {
        score = GetComponent<Score>();
        audioSource = GetComponent<AudioSource>();
        movement = loadBall.selectedPrefab.GetComponent<Movement>();
        bonus = loadBall.selectedPrefab.GetComponent<Bonus>();
        winGameCanv.enabled = false;
        endGameCanvas.enabled = false;  
    }

    public void Update()
    {
        LostGame();
        WinGame();
    }
    private void WinGame()
    {
        if (bonus.IncreaseBonus() == winGameBonusAmount || score.scoreAmount >= winGameScoreAmount)
        {
            StartCoroutine(WinGameSeq());
        }
    }
    private void LostGame()
    {
        if(movement.isCollision && !isFinish) 
        {
            bonusSpawner.SetActive(false);
            endGameCanvas.enabled = true;
        }
    }

    public IEnumerator WinGameSeq()
    {
        isFinish = true;
        movement.enabled = false;
        winGameCanv.enabled = true;       
        audioSource.PlayOneShot(victory);
        bonus.enabled = false;
        obstacleSpawn.SetActive(false);
        bonusSpawner.SetActive(false);
        yield return new WaitForSeconds(3f);
        audioSource.Stop();
        audioSource.Stop();
        yield return null;
    }
}
