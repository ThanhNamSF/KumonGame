using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopWallCollision : MonoBehaviour {

    private ChallengeControllerLv1 gc;

    void Awake()
    {
        gc = FindObjectOfType<ChallengeControllerLv1>();

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Balloon")
        {
            Text numberText = other.gameObject.GetComponentInChildren<Text>();
            try
            {
                int number = int.Parse(numberText.text);
                gc.BalloonDisappear(number);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
            other.gameObject.SetActive(false);

        }
    }
}
