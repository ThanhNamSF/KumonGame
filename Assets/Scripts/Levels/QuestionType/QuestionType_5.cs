using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionType_5 : QuestionType_2 {
    public Transform[] PositionInput_3;
    public Transform[] PositionInput_4;

    // Use this for initialization
    public override void SetInputFieldPosition(int n, List<Answer> answerSelecteds)
    {
        for (int i = 0; i < n; i++)
        {
            switch(answerSelecteds[i].Image[answerSelecteds[i].Image.Length - 1])
            {
                case '1':
                    results[i].transform.position = PositionInput_1[i].position;
                    break;
                case '2':
                    results[i].transform.position = PositionInput_2[i].position;
                    break;
                case '3':
                    results[i].transform.position = PositionInput_3[i].position;
                    break;
                case '4':
                    results[i].transform.position = PositionInput_4[i].position;
                    break;
                default:
                    break;
            }
        }
    }
}
