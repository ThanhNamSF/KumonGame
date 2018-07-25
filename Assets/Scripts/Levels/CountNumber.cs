using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountNumber : MonoBehaviour {

    private Animation anim;

    void Awake()
    {
        anim = GetComponent<Animation>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        if (anim != null)
            anim.Play();
    }

    //Set in event timeline
    public void StartGame()
    {
        ChallengeControllerLv1.gameStart = true;
        gameObject.SetActive(false);
    }
}
