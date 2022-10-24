using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public int winGameBonusAmount = 50;
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

    void Start()
    {
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
        if (bonus.IncreaseBonus() == winGameBonusAmount)
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
        winGameCanv.enabled = true;       
        audioSource.PlayOneShot(victory);
        yield return new WaitForSeconds(3f);
        audioSource.Stop();
        audioSource.Stop();
        movement.enabled = false;
        bonus.enabled = false;
        obstacleSpawn.SetActive(false);
        bonusSpawner.SetActive(false);
        yield return null;
    }
}
