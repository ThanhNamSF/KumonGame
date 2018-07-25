using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionType_4 : QuestionAbstract {

    public Text[] numbers;
    public ClickOnImage[] circles;

    public override void DisplayAnswers(int n, List<Answer> answerSelecteds)
    {
        for (int i = 0; i < n; i++)
        {
            rawImages[i].texture = Resources.Load("Images/" + answerSelecteds[i].Image) as Texture2D;
            string imageName = answerSelecteds[i].Image;
            circles[i].imageName = imageName.Remove(imageName.Length - 1);
            circles[i].ResetResult();
            numbers[i].text = answerSelecteds[i].Result.ToString();
        }
    }

    public override void Submit(List<Answer> answerSelecteds, GameObject[] starAwards, GameObject[] wrongAnswers)
    {
        for (int i = 0; i < answerSelecteds.Count; i++)
        {
            if (Int32.Parse(answerSelecteds[i].Result) == circles[i].getResult())
            {
                starAwards[i].SetActive(true);
                starAwards[i].transform.position = resultPositions[i].position;
            }
            else
            {
                wrongAnswers[i].SetActive(true);
                wrongAnswers[i].transform.position = resultPositions[i].position;
            }
        }
    }

    public void SubmitToCalculateSum(List<Answer> answerSelecteds, GameObject[] starAwards, GameObject[] wrongAnswers)
    {
        for (int i = 0; i < answerSelecteds.Count; i++)
        {
            if (Int32.Parse(answerSelecteds[i].Result) + circles[i].getResult() == 10)
            {
                starAwards[i].SetActive(true);
                starAwards[i].transform.position = resultPositions[i].position;
            }
            else
            {
                wrongAnswers[i].SetActive(true);
                wrongAnswers[i].transform.position = resultPositions[i].position;
            }
        }
    }
}
