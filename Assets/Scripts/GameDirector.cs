using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameDirector : MonoBehaviour
{
    private GameObject scoreText;
    public static GameDirector Instance;
    bool chacknowScore = false; //스코어 텍스트 오브젝트가 가르키는 값을 변경해야 하는지 확인하는 변수.
    int sceneNumber = 0; //지금 있는 씬을 체크하는 변수.
    //0: 시작 씬
    //1: 게임 씬
    //2: 게임 종료 씬

    [SerializeField] private int score = 0;

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
        ArrowController.onScoreMinus += MinusScore;
        TimeController.onEnd += ChangeSceneForEnd;

    }

    void Update()
    {
        if (sceneNumber == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeSceneForGame();
            }
        }
        else if (sceneNumber == 1)
        {
            if (chacknowScore == true)
            {
                changeTextObject();
            }
            this.scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
            //TextMeshProUGUI의 UGUI는 UI일 때 붙는 것으로, 이것을 빼면 UI에서는 오류가 난다.
            //.ToString()는 score을 문자열로 변환하기 위해 사용하는 것으로 그냥 +를 하면 string과 int를 더하는 것이 되어 프로그램이 알아차리지 못함.
        }
        else if (sceneNumber == 2)
        {
            if (chacknowScore == true)
            {
                changeTextObject();
            }
            this.scoreText.GetComponent<TextMeshProUGUI>().text = "Your Score: " + score.ToString() + "!";
        }
    }

    void AddScore()
    {
        score += 100;
    }

    void MinusScore()
    {
        score -= 100;
    }

    void ChangeSceneForGame()
    {
        SceneManager.LoadScene("GameScene");
        chacknowScore = true;
        sceneNumber = 1;
    }

    void ChangeSceneForEnd()
    {
        SceneManager.LoadScene("EndScene");
        chacknowScore = true;
        sceneNumber = 2;
    }

    void changeTextObject()
    {
        this.scoreText = GameObject.Find("Score");
        chacknowScore = false;
    }
}
