using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionType_2 : QuestionAbstract {
    public InputField[] results;
    public Transform[] PositionInput_1;
    public Transform[] PositionInput_2;

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

    // Use this for initialization
    public virtual void SetInputFieldPosition(int n, List<Answer> answerSelecteds)
    {
        for (int i = 0; i < n; i++)
        {
            if (answerSelecteds[i].Image[answerSelecteds[i].Image.Length - 1] == '1')
            {
                results[i].transform.position = PositionInput_1[i].position;
            }
            else
            {
                results[i].transform.position = PositionInput_2[i].position;
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
