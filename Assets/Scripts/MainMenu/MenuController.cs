using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel1()
    {
        NavigationController.instance.LoadLevel(1);
    }

    public void LoadLevel2()
    {
        NavigationController.instance.LoadLevel(2);
    }

    public void LoadLevel3()
    {
        NavigationController.instance.LoadLevel(3);
    }

    public void LoadLevel4()
    {
        NavigationController.instance.LoadLevel(4);
    }

    public void LoadChallenge1()
    {
        NavigationController.instance.LoadChallenge1();
    }


}
