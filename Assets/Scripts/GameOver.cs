using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] Canvas endGameCanvas;
    [SerializeField] ParticleSystem explosionParticle;
    public bool endGame = false;
    Bonus bonus;

    private void Start()
    {
        bonus = GetComponent<Bonus>();
        endGameCanvas.enabled = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (bonus.isUntouchable == true) return;
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
