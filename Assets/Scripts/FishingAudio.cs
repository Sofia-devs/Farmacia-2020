using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingAudio : MonoBehaviour
{
    public AudioSource splashSound;
    public AudioClip hoverFx;
    public AudioClip clickFx;


    public void HoverSound()
    {
        splashSound.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        splashSound.PlayOneShot(clickFx);
    }
}
