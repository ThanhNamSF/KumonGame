using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject[] Levels;

    private Slider processingSlider;
    private GameObject finishLevel;
    private Text percentText;
    private GameObject[] starAwards;
    private GameObject[] wrongAnswers;
    private GameObject reward;
    public KuMonDatabase kumonDatabase;
    private float exp;
    private int currentLevel;
    private int levelSelected;

    void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        //PlayerPrefs.SetInt("Level", 1);
        //PlayerPrefs.SetFloat("Exp", 0);
        UnlockLevel();
    }

    public void SetProcessingGameObject(Slider slider, GameObject finish, Text percent, GameObject rewardFinish)
    {
        percentText = percent;
        finishLevel = finish;
        processingSlider = slider;
        reward = rewardFinish;
    }

    public void SetAwardGameObject(GameObject[] _starAward, GameObject[] _wrongAnswer)
    {
        starAwards = _starAward;
        wrongAnswers = _wrongAnswer;
    }
    // Use this for initialization
    void Start () {
        kumonDatabase = new KuMonDatabase();
    }

    public void UnlockLevel()
    {  
        currentLevel = PlayerPrefs.GetInt("Level");
        if (currentLevel == 0)
        {
            currentLevel = 1;
            exp = 0;
            PlayerPrefs.SetInt("Level", currentLevel);
            PlayerPrefs.SetFloat("Exp", exp);
        }
        else
        {
            Levels = new GameObject[currentLevel];
            for(int i = 1; i <= currentLevel; i++)
            {
                Levels[i - 1] = GameObject.FindGameObjectWithTag("Level" + i);
            }
            UnlockLevel(currentLevel);
        }
    }

    void UnlockLevel(int level)
    {
        for(int i = 0; i < level; i++)
        {
            Levels[i].GetComponentInChildren<Button>().GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            if(i > 0)
                Levels[i].GetComponentInChildren<RawImage>().gameObject.SetActive(false);
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseProcess()
    {
        if (processingSlider.value < processingSlider.maxValue)
        {
            processingSlider.value++;
            float percent = (processingSlider.value * 100) / processingSlider.maxValue;
            percentText.text = "" + percent + "%";
            PlayerPrefs.SetFloat("Exp", processingSlider.value);
            if (processingSlider.value >= processingSlider.maxValue)
            {
                DisableWrongAnswer();
                finishLevel.SetActive(true);
                reward.SetActive(true);
                if(levelSelected == currentLevel)
                {
                    currentLevel++;
                    exp = 0f;
                    PlayerPrefs.SetInt("Level", currentLevel);
                    PlayerPrefs.SetFloat("Exp", exp);
                }
            }
        }
    }

    private void DisableWrongAnswer()
    {
        for (int i = 0; i < wrongAnswers.Length; i++)
        {
            wrongAnswers[i].SetActive(false);
        }
    }

    public void SetExpAndLevel(int level)
    {
        levelSelected = level;
        exp = levelSelected < currentLevel ? processingSlider.maxValue : PlayerPrefs.GetFloat("Exp");
        processingSlider.value = exp;
        percentText.text = "" + (processingSlider.value * 100) / processingSlider.maxValue + "%";
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
