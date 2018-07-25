using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectOverTime : MonoBehaviour {

    private Animation anim;
    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animation>();
    }

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
    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
