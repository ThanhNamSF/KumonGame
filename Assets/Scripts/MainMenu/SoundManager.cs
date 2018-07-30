using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource collectStar;
    public AudioSource backgroundMusic;
    public AudioSource rewardMusic;
    public AudioClip[] backgroundMusicArr;
    public static SoundManager instance;
    private bool playBackgroundMusic = true;
    int index = 1;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!backgroundMusic.isPlaying && playBackgroundMusic)
        {
            backgroundMusic.clip = backgroundMusicArr[(index++) % backgroundMusicArr.Length];
            backgroundMusic.Play();
        }
    }

    public void PLayCollectStar()
    {
        if (collectStar.isPlaying)
            collectStar.Stop();
        collectStar.Play();
    }

    public void PlayRewardMusic()
    {
        playBackgroundMusic = false;
        if(backgroundMusic.isPlaying)
            backgroundMusic.Stop();
        rewardMusic.Play();
    }

    public void PlayBackgroundMusic()
    {
        playBackgroundMusic = true;
        if(rewardMusic.isPlaying)
            rewardMusic.Stop();
    }
}
