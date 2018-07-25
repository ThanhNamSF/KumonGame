using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour {

    public static NavigationController instance;
    public string[] Levels;
    public string[] Challenges;
    public string Menu;

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
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadLevel(int level)
    {
        if(GameController.instance.GetCurrentLevel() >= level)
            Application.LoadLevel(Levels[level - 1]);
    }

    public void LoadChallenge1()
    {
        Application.LoadLevel(Challenges[0]);
    }

    public void LoadMenu()
    {
        Application.LoadLevel(Menu);
    }
}
