using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeControllerLv1 : MonoBehaviour {

    public float minTime;
    public float maxTime;
    public float minXSpawn;
    public float maxXSpawn;
    public float ySpawn;
    public GameObject missionPanel;
    public GameObject pauseGamePanel;
    public GameObject gameOverPanel;
    public GameObject completeGamePanel;
    public GameObject countNumber;
    public Text scoreText;
    public static bool gameStart;
    public static bool isPauseGame = false;
    public GameObject[] hearts;

    private bool canSpawn;
    private List<int> randList; // two random number
    private int score = 0;
    private int indexHeart = 0;
    private Text missionText;
    private bool endGame = false;

    void Awake()
    {
        randList = new List<int>();
        missionText = missionPanel.GetComponentInChildren<Text>();
        if (missionText != null)
        {
            SetRandNumber(randList, 2, 1, 10);
            missionText.text = SetText(randList[0], randList[1]);
        }
    }
    // Use this for initialization
    void Start()
    {
        canSpawn = true;
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            if (canSpawn)
            {
                StartCoroutine(SpawnBalloon());
            }
        }
    }

    IEnumerator SpawnBalloon()
    {
        GameObject balloon = ObjectPooler.SharedIntance.GetPooledObject("Balloon");
        if (balloon != null)
        {
            balloon.transform.position = new Vector2(Random.Range(minXSpawn, maxXSpawn), ySpawn);
            balloon.SetActive(true);
        }
        canSpawn = false;
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        canSpawn = true;
    }

    public void StartGame()
    {
        missionPanel.SetActive(false);
        countNumber.SetActive(true);
        BalloonMovement.SetNumberList(randList[0], randList[1]);
        ResetGame();
        isPauseGame = false;
    }

    public void QuitGame()
    {
        NavigationController.instance.LoadMenu();
    }

    //Set text when start Game
    private string SetText(int a, int b)
    {
        string text = "Your mission: You must shoot down all balloons have number " + a + " or " + b + ". Each balloon you hit will get 1 point. If you hit the balloons have number different with " + a + " and " + b + ", you will lose a heart. If you let the balloons have number " + a + " or " + b + " disappear, you will lose a heart. If you lose all of hearts, your mission fail and game over. If you get 10 point, you will complete the challenge.";
        return text;
    }

    // Get Random number when start Game
    private void SetRandNumber(List<int> arrRand, int length, int min, int max)
    {
        arrRand.Clear();
        int n = max - min + 1;
        if (length > n)
            return;
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = i + min;
        }
        for (int i = 0; i < length; i++)
        {
            int indexRandom = Random.Range(0, n);
            arrRand.Add(arr[indexRandom]);
            int temp = arr[indexRandom];
            arr[indexRandom] = arr[n - 1];
            arr[n - 1] = temp;
            n--;
        }
    }

    //Set score and heart when hit balloon
    public void HitBalloon(int number)
    {
        if (!endGame)
        {
            if (randList.Contains(number))
            {
                score++;
                scoreText.text = "Score: " + score;
            }
            else
            {
                if (indexHeart < 3)
                {
                    hearts[indexHeart].SetActive(false);
                    indexHeart++;
                }
                if (indexHeart >= 3)
                    if (score >= 10)
                    {
                        CompleteGame();
                    }
                    else
                    {
                        GameOver();
                    }
            }
        }
    }

    //Set heart when balloon disappear
    public void BalloonDisappear(int number)
    {
        if (!endGame)
        {
            if (randList.Contains(number))
            {
                if (indexHeart < 3)
                {
                    hearts[indexHeart].SetActive(false);
                    indexHeart++;
                }
                if (indexHeart >= 3)
                    GameOver();
            }
        }
    }

    public void PauseGame()
    {
        if (!isPauseGame)
        {
            pauseGamePanel.SetActive(true);
            isPauseGame = true;
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        if (isPauseGame)
        {
            isPauseGame = false;
            pauseGamePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isPauseGame = true;
        endGame = true;
    }

    public void CompleteGame()
    {
        completeGamePanel.SetActive(true);
        isPauseGame = true;
        endGame = true;
    }

    public void PlayAgain()
    {
        SetRandNumber(randList, 2, 1, 10);
        missionText.text = SetText(randList[0], randList[1]);
        missionPanel.SetActive(true);
        completeGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        ObjectPooler.SharedIntance.SetActiveObjects("Balloon", false);
        gameStart = false;
    }

    private void ResetGame()
    {

        score = 0;
        scoreText.text = "Score: 0";
        indexHeart = 0;
        for (int i = 0; i < 3; i++)
            hearts[i].SetActive(true);
        endGame = false;
    }
}
