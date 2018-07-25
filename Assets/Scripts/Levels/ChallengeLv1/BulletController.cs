using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

    public float force;

    private Rigidbody2D myRigidbody;
    private ChallengeControllerLv1 gc;
    // Use this for initialization
    void Awake()
    {
        gc = FindObjectOfType<ChallengeControllerLv1>();
        myRigidbody = GetComponent<Rigidbody2D>();
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
        if (myRigidbody != null)
        {
            myRigidbody.AddForce(transform.up * force);
        }
    }

    void OnDisable()
    {
        if (myRigidbody != null)
        {
            myRigidbody.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Balloon")
        {
            Text numberText = other.gameObject.GetComponentInChildren<Text>();
            try
            {
                int number = int.Parse(numberText.text);
                gc.HitBalloon(number);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }

            GameObject balloonExplosion = ObjectPooler.SharedIntance.GetPooledObject("BalloonExplosion");
            if (balloonExplosion != null)
            {
                balloonExplosion.transform.position = other.transform.position;
                balloonExplosion.SetActive(true);
            }
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
