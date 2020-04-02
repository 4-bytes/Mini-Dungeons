using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Handles music and sound effects

public class AudioController : MonoBehaviour
{
    public static AudioController audioManager;
    public bool playMusic;
    public bool playSound;
    public AudioSource menuMusic;
    public AudioSource levelMusic;
    public AudioSource deathMusic;
    public AudioSource victoryMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playDeathMusic()
    {
        levelMusic.Stop();

        deathMusic.Play();
    }

    public void playVictoryMusic()
    {
        levelMusic.Stop();

        victoryMusic.Play();
    }



}
