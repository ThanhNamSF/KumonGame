using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionType_3 : QuestionAbstract
{
    public Toggle[] toggles_1;
    public Toggle[] toggles_2;

    public void SetEmptyCheck()
    {
        for (int i = 0; i < 4; i++)
        {
            if(toggles_1.Length > i)
                toggles_1[i].isOn = false;
            if(toggles_2.Length > i)
                toggles_2[i].isOn = false;
        }
    }

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
            if ((answerSelecteds[i].Result == "0" && toggles_1[i].isOn) || (answerSelecteds[i].Result == "1" && toggles_2[i].isOn))
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

    public void SubmitSingleToggle(List<Answer> answerSelecteds, GameObject[] starAwards, GameObject[] wrongAnswers)
    {
        for (int i = 0; i < answerSelecteds.Count; i++)
        {
            if ((answerSelecteds[i].Result == "1" && toggles_1[i].isOn) || (answerSelecteds[i].Result == "0" && !toggles_1[i].isOn))
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
