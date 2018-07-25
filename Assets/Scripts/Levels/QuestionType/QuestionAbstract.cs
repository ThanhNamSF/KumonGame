using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class QuestionAbstract : MonoBehaviour {

    public RawImage[] rawImages;
    //public InputField[] results;
    public Transform[] resultPositions;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void DisplayAnswers(int n, List<Answer> answerSelecteds);
    public abstract void Submit(List<Answer> answerSelecteds, GameObject[] starAwards, GameObject[] wrongAnswers);
}
