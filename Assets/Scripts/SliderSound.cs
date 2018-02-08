using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderSound : MonoBehaviour {

    AudioSource sliderAud;

    public void Awake()
    {
        sliderAud = GetComponent<AudioSource>();

    }

    public void PlaySound()
    {
        if (!sliderAud.isPlaying)
        {
            sliderAud.Play();
        }
    }
}
    