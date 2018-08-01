using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource collectStar;
    public AudioSource backgroundMusic;
    public AudioSource rewardMusic;
    public static SoundManager instance;
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
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PLayCollectStar()
    {
        if (collectStar.isPlaying)
            collectStar.Stop();
        collectStar.Play();
    }

    public void PlayRewardMusic()
    {
        if(backgroundMusic.isPlaying)
            backgroundMusic.Stop();
        rewardMusic.Play();
    }

    public void PlayBackgroundMusic()
    {
        if(rewardMusic.isPlaying)
            rewardMusic.Stop();
        backgroundMusic.Play();
    }
}
