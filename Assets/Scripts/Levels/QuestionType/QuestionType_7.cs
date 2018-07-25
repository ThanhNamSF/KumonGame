using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionType_7 : QuestionAbstract
{
    public InputField[] Hours;
    public InputField[] Minutes;

    public override void DisplayAnswers(int n, List<Answer> answerSelecteds)
    {
        for (int i = 0; i < n; i++)
        {
            rawImages[i].texture = Resources.Load("Images/" + answerSelecteds[i].Image) as Texture2D;
        }
    }

    public override void Submit(List<Answer> answerSelecteds, GameObject[] starAwards, GameObject[] wrongAnswers)
    {
        for (int i = 0; i < answerSelecteds.Count; i++)
        {
            string[] timeSplit = answerSelecteds[i].Result.Split(':');
            if (!string.IsNullOrEmpty(Hours[i].text) &&
                Int32.Parse(timeSplit[0]) == Int32.Parse(Hours[i].text) &&
                Int32.Parse(timeSplit[1]) == Int32.Parse(Minutes[i].text))
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

    public void SetEmptyInputField()
    {
        for (int i = 0; i < 4; i++)
        {
            Hours[i].text = "";
            Minutes[i].text = "";
        }
    }
}
