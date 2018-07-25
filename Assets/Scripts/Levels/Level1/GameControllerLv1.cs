using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerLv1 : MonoBehaviour {

    public GameObject FinishLevel;
    public Text Question;
    public Button submitButton;
    public Button nextButton;
    public GameObject reward;

    public GameObject[] QuestionsType;

    public QuestionType_1 questionUI1, questionUI2, questionUI6;
    public QuestionType_2 questionUI3;
    public QuestionType_3 questionUI4;
    public QuestionType_4 questionUI5;

    public GameObject[] starAwards;
    public GameObject[] wrongAnswers;

    public Slider processingSlider;
    public Text percentText;
    private List<Answer> answerSelecteds = new List<Answer>();
    private Question questionSelected;
    int questionNumber = 1;

    // Use this for initialization
    void Start () {
        GameController.instance.SetAwardGameObject(starAwards, wrongAnswers);
        GameController.instance.SetProcessingGameObject(processingSlider, FinishLevel, percentText, reward);
        GameController.instance.SetExpAndLevel(1);
        questionSelected = GameController.instance.kumonDatabase.GetRabdomQuestionByGrade_Level(1, 1);
        //questionSelected = _kumonDatabase.GetQuestionByID (1, 1, 8);
        answerSelecteds = GameController.instance.kumonDatabase.GetRandomAnswerFollowQuestion(questionSelected.ID);
        //questionType7And8.DisplayAnswers (4, answerSelecteds);
        DisplayAnswer(questionSelected.ID);
        Question.text = "" + questionNumber + ". " + questionSelected.Content;
        questionNumber++;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Submit()
    {
        //1 2 7 8
        //4 6
        //3
        //5
        submitButton.gameObject.SetActive(false);
        StartCoroutine(WaitingForActiveNextButton());
        switch (questionSelected.ID)
        {
            case 1:
                questionUI1.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 2:
                questionUI2.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 3:
                questionUI3.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 4:
            case 6:
                questionUI4.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 5:
                questionUI5.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 7:
            case 8:
                questionUI6.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 9:
                questionUI5.SubmitToCalculateSum(answerSelecteds, starAwards, wrongAnswers);
                break;
            default:
                break;
        }
    }

    IEnumerator WaitingForActiveNextButton()
    {
        yield return new WaitForSeconds(3f);
        nextButton.gameObject.SetActive(true);
    }

    public void NextQuestion()
    {
        submitButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(false);

        SetEmptyQuestion();

        //int rand = Random.Range (1, 9);
        questionSelected = GameController.instance.kumonDatabase.GetRabdomQuestionByGrade_Level(1, 1);

        answerSelecteds = GameController.instance.kumonDatabase.GetRandomAnswerFollowQuestion(questionSelected.ID);

        Question.text = "" + questionNumber + ". " + questionSelected.Content;
        questionNumber++;

        DisplayAnswer(questionSelected.ID);
    }

    private void DisplayAnswer(int questionID)
    {
        switch (questionID)
        {
            case 1:
                QuestionsType[0].SetActive(true);
                questionUI1.DisplayAnswers(4, answerSelecteds);
                break;
            case 2:
                QuestionsType[1].SetActive(true);
                questionUI2.DisplayAnswers(4, answerSelecteds);
                break;
            case 3:
                QuestionsType[2].SetActive(true);
                questionUI3.DisplayAnswers(4, answerSelecteds);
                questionUI3.SetInputFieldPosition(4, answerSelecteds);
                break;
            case 4:
            case 6:
                QuestionsType[3].SetActive(true);
                questionUI4.DisplayAnswers(4, answerSelecteds);
                break;
            case 5:
            case 9:
                QuestionsType[4].SetActive(true);
                questionUI5.DisplayAnswers(4, answerSelecteds);
                break;
            case 7:
            case 8:
                QuestionsType[5].SetActive(true);
                questionUI6.DisplayAnswers(4, answerSelecteds);
                break;
            default:
                break;
        }
    }

    private void SetEmptyQuestion()
    {
        DisableWrongAnswer();

        switch (questionSelected.ID)
        {
            case 1:
                questionUI1.SetEmptyInputField();
                QuestionsType[0].SetActive(false);
                break;
            case 2:
                questionUI2.SetEmptyInputField();
                QuestionsType[1].SetActive(false);
                break;
            case 3:
                questionUI3.SetEmptyInputField();
                QuestionsType[2].SetActive(false);
                break;
            case 4:
            case 6:
                questionUI4.SetEmptyCheck();
                QuestionsType[3].SetActive(false);
                break;
            case 5:
            case 9:
                QuestionsType[4].SetActive(false);
                break;
            case 7:
            case 8:
                questionUI6.SetEmptyInputField();
                QuestionsType[5].SetActive(false);
                break;
            default:
                break;
        }
    }

    private void DisableWrongAnswer()
    {
        for (int i = 0; i < wrongAnswers.Length; i++)
        {
            wrongAnswers[i].SetActive(false);
        }
    }

    public void BackMenu()
    {
        NavigationController.instance.LoadMenu();
    }

    public void NextLevel()
    {
        NavigationController.instance.LoadLevel(2);
    }

}
