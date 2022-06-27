using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    [SerializeField]
    private AudioSource sound;
    private float musicVol = 1f;
    
    void Start()
    {
        sound.Play();
    }
    
    void Update()
    {
        sound.volume = musicVol;
    }

    public void UpdateVolume(float vol)
    {
        musicVol = vol;
    }
}
