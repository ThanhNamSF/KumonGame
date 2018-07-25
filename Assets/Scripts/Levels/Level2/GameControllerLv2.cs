using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerLv2 : MonoBehaviour {

    public GameObject FinishLevel;
    public Text Question;
    public Button submitButton;
    public Button nextButton;
    public GameObject reward;

    public GameObject[] QuestionsType;

    public QuestionType_1 questionUI1, questionUI2, questionUI5, questionUI6;
    public QuestionType_2 questionUI3;
    public QuestionType_5 questionUI4;

    public GameObject[] starAwards;
    public GameObject[] wrongAnswers;

    public Slider processingSlider;
    public Text percentText;
    private List<Answer> answerSelecteds = new List<Answer>();
    private Question questionSelected;
    int questionNumber = 1;

    // Use this for initialization
    void Start()
    {

        GameController.instance.SetAwardGameObject(starAwards, wrongAnswers);
        GameController.instance.SetProcessingGameObject(processingSlider, FinishLevel, percentText, reward);
        GameController.instance.SetExpAndLevel(2);
        questionSelected = GameController.instance.kumonDatabase.GetRabdomQuestionByGrade_Level(1, 2);
        //questionSelected = _kumonDatabase.GetQuestionByID (1, 1, 8);
        answerSelecteds = GameController.instance.kumonDatabase.GetRandomAnswerFollowQuestion(questionSelected.ID);
        //questionType7And8.DisplayAnswers (4, answerSelecteds);
        DisplayAnswer(questionSelected.ID);
        Question.text = "" + questionNumber + ". " + questionSelected.Content;
        questionNumber++;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Submit()
    {
        submitButton.gameObject.SetActive(false);
        StartCoroutine(WaitingForActiveNextButton());
        switch (questionSelected.ID)
        {
            case 10:
                questionUI1.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 11:
                questionUI2.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 12:
                questionUI3.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 13:
                questionUI4.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 14:
            case 15:
                questionUI5.Submit(answerSelecteds, starAwards, wrongAnswers);
                break;
            case 16:
                questionUI6.Submit(answerSelecteds, starAwards, wrongAnswers);
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
        questionSelected = GameController.instance.kumonDatabase.GetRabdomQuestionByGrade_Level(1, 2);

        answerSelecteds = GameController.instance.kumonDatabase.GetRandomAnswerFollowQuestion(questionSelected.ID);

        Question.text = "" + questionNumber + ". " + questionSelected.Content;
        questionNumber++;

        DisplayAnswer(questionSelected.ID);
    }

    private void DisplayAnswer(int questionID)
    {
        switch (questionID)
        {
            case 10:
                QuestionsType[0].SetActive(true);
                questionUI1.DisplayAnswers(4, answerSelecteds);
                break;
            case 11:
                QuestionsType[1].SetActive(true);
                questionUI2.DisplayAnswers(4, answerSelecteds);
                break;
            case 12:
                QuestionsType[2].SetActive(true);
                questionUI3.DisplayAnswers(4, answerSelecteds);
                questionUI3.SetInputFieldPosition(4, answerSelecteds);
                break;
            case 13:
                QuestionsType[3].SetActive(true);
                questionUI4.DisplayAnswers(4, answerSelecteds);
                questionUI4.SetInputFieldPosition(4, answerSelecteds);             
                break;
            case 14:
            case 15:
                QuestionsType[4].SetActive(true);
                questionUI5.DisplayAnswers(4, answerSelecteds);
                break;
            case 16:
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
            case 10:
                questionUI1.SetEmptyInputField();
                QuestionsType[0].SetActive(false);
                break;
            case 11:
                questionUI2.SetEmptyInputField();
                QuestionsType[1].SetActive(false);
                break;
            case 12:
                questionUI3.SetEmptyInputField();
                QuestionsType[2].SetActive(false);
                break;
            case 13:
                questionUI4.SetEmptyInputField();
                QuestionsType[3].SetActive(false);
                break;
            case 14:
            case 15:
                questionUI5.SetEmptyInputField();
                QuestionsType[4].SetActive(false);
                break;
            case 16:
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
        NavigationController.instance.LoadLevel(3);
    }
}
