using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOject : MonoBehaviour {
    public float speed = 10f;
    // Use this for initialization
    void Awake () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
