using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] public AudioSource SFX;

    public AudioClip doorSound;
    public AudioClip cameraCrash;
    //public AudioClip jumpSound;

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
