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

    public void SubmitRank(List<Answer> answerSelecteds, GameObject[] starAwards, GameObject[] wrongAnswers)
    {
        for (int res = 0; res < results.Length; res++)
        {
            int count = 1;
            for (int i = 0; i < answerSelecteds.Count; i++)
            {
                if (string.Compare(answerSelecteds[res].Result, answerSelecteds[i].Result) < 0)
                {
                    count++;
                }
            }
            if (!string.IsNullOrEmpty(results[res].text) && Int32.Parse(results[res].text) == count)
            {
                starAwards[res].SetActive(true);
                starAwards[res].transform.position = resultPositions[res].position;
            }
            else
            {
                wrongAnswers[res].SetActive(true);
                wrongAnswers[res].transform.position = resultPositions[res].position;
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
