using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music; 
    [SerializeField] AudioSource sfx;

  
    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void PlayMusic(AudioClip clip, bool loop) {
        if (clip == null) {
            return;
        } 
        music.clip = clip;
        music.loop = loop;  
        music.Play();
    }

    public void playSFX(AudioClip clip) {
        if (clip== null) {
            return;
        }
        sfx.PlayOneShot(clip);
    }
}
