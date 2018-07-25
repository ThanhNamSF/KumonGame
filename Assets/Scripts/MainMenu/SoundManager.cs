using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource collectStar;
    public AudioSource backgroundMusic;
    public AudioClip[] backgroundMusicArr;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (!backgroundMusic.isPlaying)
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
}
