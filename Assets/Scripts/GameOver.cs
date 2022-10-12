using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] Canvas endGameCanvas;
    Movement movement;


    private void Start()
    {
        movement = GameObject.FindWithTag("Player").GetComponent<Movement>();
        endGameCanvas.enabled = false;
    }

    private void Update()
    {
        if (movement.isCollision == true)
        {
            StartCoroutine(EndGame());
        }
        
    }
    private IEnumerator EndGame()
    {
            
            //GetComponent<Movement>().enabled = false;
            yield return new WaitForSeconds(1f);
            endGameCanvas.enabled = true;
            yield return null;
        
    }
}
