using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerLv4 : MonoBehaviour {

    public GameObject FinishLevel;
    public Text Question;
    public Button submitButton;
    public Button nextButton;
    public GameObject reward;

    public GameObject[] QuestionsType;

    public QuestionType_7 questionUI1;

    public GameObject[] starAwards;
    public GameObject[] wrongAnswers;

    public Slider processingSlider;
    public Text percentText;
    private List<Answer> answerSelecteds = new List<Answer>();
    private Question questionSelected;
    int questionNumber = 1;

    void Start()
    {
        GameController.instance.SetAwardGameObject(starAwards, wrongAnswers);
        GameController.instance.SetProcessingGameObject(processingSlider, FinishLevel, percentText, reward);
        GameController.instance.SetExpAndLevel(4);
        questionSelected = GameController.instance.kumonDatabase.GetRabdomQuestionByGrade_Level(1, 4);
        //questionSelected = GameController.instance.kumonDatabase.GetQuestionByID(1, 3, 22);
        //questionSelected = _kumonDatabase.GetQuestionByID (1, 1, 8);
        answerSelecteds = GameController.instance.kumonDatabase.GetRandomAnswerFollowQuestion(questionSelected.ID);
        //questionType7And8.DisplayAnswers (4, answerSelecteds);
        DisplayAnswer(questionSelected.ID);
        Question.text = "" + questionNumber + ". " + questionSelected.Content;
        questionNumber++;
    }

    void Update()
    {

    }

    public void Submit()
    {
        submitButton.gameObject.SetActive(false);
        StartCoroutine(WaitingForActiveNextButton());
        switch (questionSelected.ID)
        {
            case 23:
                questionUI1.Submit(answerSelecteds, starAwards, wrongAnswers);
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
        questionSelected = GameController.instance.kumonDatabase.GetRabdomQuestionByGrade_Level(1, 4);

        answerSelecteds = GameController.instance.kumonDatabase.GetRandomAnswerFollowQuestion(questionSelected.ID);

        Question.text = "" + questionNumber + ". " + questionSelected.Content;
        questionNumber++;

        DisplayAnswer(questionSelected.ID);
    }

    private void DisplayAnswer(int questionID)
    {
        switch (questionID)
        {
            case 23:
                QuestionsType[0].SetActive(true);
                questionUI1.DisplayAnswers(4, answerSelecteds);
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
            case 23:
                questionUI1.SetEmptyInputField();
                QuestionsType[0].SetActive(false);
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
}
