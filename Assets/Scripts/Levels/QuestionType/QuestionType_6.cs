using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionType_6 : MonoBehaviour {
    public AnswerType[] Answer;
    public int Max;
    public int Min;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayAnswer(int n)
    {
        for(int i = 0; i < n; i++)
        {
            Answer[i].SetRandomNumber(Min, Max);
        }
    }

    public void ClickOnAnswer(string indexStr)
    {
        var answerTypeIndex = Int32.Parse(indexStr[0].ToString());
        var indexPosition = Int32.Parse(indexStr[1].ToString());
        if (Answer[answerTypeIndex].PositionInOriginal(indexPosition))
        {
            Answer[answerTypeIndex].SetArrangePosition(indexPosition);
        }
        else
        {
            Answer[answerTypeIndex].SetOriginalPosition(indexPosition);
        }
    }

    public void Submit(int n, GameObject[] starAwards, GameObject[] wrongAnswers)
    {
        for(int i = 0; i < n; i++)
        {
            if (Answer[i].CheckResult())
            {
                starAwards[i].SetActive(true);
                starAwards[i].transform.position = Answer[i].Arrow.transform.position;
                Answer[i].HiddenArrow();
            }
            else
            {
                wrongAnswers[i].SetActive(true);
                wrongAnswers[i].transform.position = Answer[i].Arrow.transform.position;
                Answer[i].HiddenArrow();
            }
        }
    }

    public void ResetPosition(int n)
    {
        for(int i = 0; i < n; i++)
        {
            Answer[i].ResetPosition();
        }
    }
}

[Serializable]
public class AnswerType
{
    public GameObject[] Numbers;
    public Transform[] ArrangePosition;
    public GameObject Arrow;

    private Vector3[] OriginalPosition;
    private int[] Result;
    private bool[] Mark;
    private int count;
    private static readonly System.Random rndNumber = new System.Random();
    private void Init()
    {
        count = Numbers.Length;
        Mark = new bool[count];
        Result = new int[count];
        Arrow.SetActive(true);
        OriginalPosition = new Vector3[count];
        for (int i = 0; i < count; i++)
        {
            OriginalPosition[i] = new Vector3(Numbers[i].transform.position.x, Numbers[i].transform.position.y, Numbers[i].transform.position.z);
        }
    }

    public void SetRandomNumber(int min, int max)
    {
        Init();
        for (int i = 0; i < count; i++)
        {
            var number = rndNumber.Next(min, max).ToString();
            Numbers[i].GetComponentInChildren<Text>().text = number;
        }
    }

    public bool CheckResult()
    {
        for(int i = 0; i < count - 1; i++)
        {
            if (Result[i] > Result[i + 1] || Result[i] == 0)
                return false;
        }
        return true;
    }

    public void SetArrangePosition(int buttonIndex)
    {
        for(int i = 0; i < count; i++)
        {
            if (!Mark[i])
            {
                Mark[i] = true;
                Numbers[buttonIndex].transform.position = ArrangePosition[i].position;
                Result[i] = Int32.Parse(Numbers[buttonIndex].GetComponentInChildren<Text>().text);
                return;
            }
        }
    }

    public void SetOriginalPosition(int buttonIndex)
    {
        for(int i = 0; i < count; i++)
        {
            if(Numbers[buttonIndex].transform.position.x == ArrangePosition[i].position.x)
            {
                Debug.Log(i);
                Mark[i] = false;
                Numbers[buttonIndex].transform.position = OriginalPosition[buttonIndex];
                Result[i] = 0;
                return;
            }
        }
    }

    public void ResetPosition()
    {
        for(int i = 0; i < count; i++)
        {
            Numbers[i].transform.position = OriginalPosition[i];
        }
    }

    public void HiddenArrow()
    {
        Arrow.SetActive(false);
    }

    public bool PositionInOriginal(int positionIndex)
    {
        return Numbers[positionIndex].transform.position.x == OriginalPosition[positionIndex].x;
    }

}
