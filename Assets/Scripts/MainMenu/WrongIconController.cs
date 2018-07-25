using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongIconController : MonoBehaviour {

    public float originalScale;

    private Vector3 scale;
    private bool isActive;
    private float t;
    // Use this for initialization
    void Start()
    {
        scale = new Vector3(originalScale, originalScale, originalScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, scale, t);
            if (transform.localScale == scale)
            {
                isActive = false;
            }
        }
    }

    void OnEnable()
    {
        isActive = true;
        t = 0;
        transform.localScale = Vector3.zero;
    }
}
