using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Collections;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;
    public int score = 0;
    private GameObject scoreText;
    public int sceneNumber = 0; //지금 있는 씬을 체크하는 변수.
    //0: 시작 씬
    //1: 게임 씬
    //2: 게임 종료 씬 (삭제)

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ArrowController.onScorePlus += AddScore;
        ArrowController.onScorePlusPlus += AddAddScore;
        ArrowController.onScoreMinus += MinusScore;
        ActiveController.onReset += Reseting;

        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            sceneNumber = 0;
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            sceneNumber = 1;
        }
        /*
        else if (SceneManager.GetActiveScene().name == "EndScene")
        {
            sceneNumber = 2;
        }
        */
        else
        {
            Debug.Log("오류!");
        }

    }

    void Update()
    {
        if (scoreText == null)
        {
            changeTextObject();
        }

        if (sceneNumber == 0)
        {

        }
        else if (sceneNumber == 1 && scoreText != null)
        {
            this.scoreText.GetComponent<TextMeshProUGUI>().text = "점수: " + score.ToString();
            //TextMeshProUGUI의 UGUI는 UI일 때 붙는 것으로, 이것을 빼면 UI에서는 오류가 난다.
            //.ToString()는 score을 문자열S로 변환하기 위해 사용하는 것으로 그냥 +를 하면 string과 int를 더하는 것이 되어 프로그램이 알아차리지 못함.
        }
        /*
        else if (sceneNumber == 2 && scoreText != null)
        {
            this.scoreText.GetComponent<TextMeshProUGUI>().text = "최종 점수: " + score.ToString();
        }
        */
    }

    void AddScore()
    {
        score += 100;
    }

    void AddAddScore()
    {
        score += 200;
    }

    void MinusScore()
    {
        score -= 100;
    }

    void changeTextObject()
    {
        this.scoreText = GameObject.Find("Score");
    }

    void Reseting()
    {
        score = 0;
    }
}
