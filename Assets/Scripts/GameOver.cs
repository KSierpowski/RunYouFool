using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] Canvas endGameCanvas;
    [SerializeField] ParticleSystem explosionParticle;
    BonusPickup bonusPickup;
    public bool endGame = false;

    private void Start()
    {
        bonusPickup = GetComponent<BonusPickup>();
        endGameCanvas.enabled = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (bonusPickup.isUntouchable == true) return;
            else
            {
                endGame = true;
                StartCoroutine(EndGame());
            }
        }
       
    }
    private IEnumerator EndGame()
    {
            explosionParticle.Play();
            GetComponent<Movement>().enabled = false;
            yield return new WaitForSeconds(1f);
            endGameCanvas.enabled = true;
            yield return null;
        
    }
}
