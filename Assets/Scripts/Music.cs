
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] Canvas muteImage;
    [SerializeField] AudioClip mainSong;
    public bool mute = false;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        muteImage.enabled = false;
        audioSource.PlayOneShot(mainSong);

    }
    private void Update()
    {   
        Mute();
    }


    private void Mute()  //Switcher to mute the main song
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            mute = !mute;
            if (!mute)
            {
                audioSource.mute = false;
                muteImage.enabled = false;
            }
            else
            {
                audioSource.mute = true;
                muteImage.enabled = true;
            }
        }
    }
}