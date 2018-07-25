using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonMovement : MonoBehaviour {

    public float minSpeed;
    public float maxSpeed;

    private Rigidbody2D myRigidbody;
    private RawImage image;
    private Text numberText;
    private float speed;
    private static List<int> numberList;
    // Use this for initialization

    void Awake()
    {
        image = GetComponentInChildren<RawImage>();
        numberText = GetComponentInChildren<Text>();
    }
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(0, 1 * speed);
    }

    void OnEnable()
    {
        if (image != null && numberText != null)
        {
            int randImg = Random.Range(1, 11);
            image.texture = Resources.Load("Challenge1/Balloon/balloon" + randImg) as Texture2D;
            if (numberList != null)
            {
                int randIndex = Random.Range(0, numberList.Count);
                numberText.text = "" + numberList[randIndex];
            }
            speed = Random.Range(minSpeed, maxSpeed);
        }
    }

    //Set random number in balloon, with 30% each number in target
    public static void SetNumberList(int a, int b)
    {
        numberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        for (int i = 0; i < 6; i++)
        {
            numberList.Add(a);
            numberList.Add(b);
        }
    }
}
