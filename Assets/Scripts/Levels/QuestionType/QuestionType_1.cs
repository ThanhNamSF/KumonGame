using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionType_1 : QuestionAbstract {
    public InputField[] results;

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
            if (!results[i].text.Equals(string.Empty) && answerSelecteds[i].Result == results[i].text)
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
            results[i].text = "";
        }
    }
}
