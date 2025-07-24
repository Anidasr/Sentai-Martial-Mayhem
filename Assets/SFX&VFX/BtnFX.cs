using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip hoverFX;
    public AudioClip clickFX;

    public void HoverSounds()
    {
        myFX.PlayOneShot(hoverFX);
    }
    public void ClickSounds()
    {
        myFX.PlayOneShot(clickFX);
    }
}
