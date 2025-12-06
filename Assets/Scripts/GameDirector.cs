using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private GameObject scoreText;
    [SerializeField] private int score = 0;
    void Start()
    {
        ArrowController.onScorePlus += AddScore;
        ArrowController.onScoreMinus += MinusScore;

    }

    void Update()
    {
        this.scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        //TextMeshProUGUI의 UGUI는 UI일 때 붙는 것으로, 이것을 빼면 UI에서는 오류가 난다.
        //.ToString()는 score을 문자열로 변환하기 위해 사용하는 것으로 그냥 +를 하면 string과 int를 더하는 것이 되어 프로그램이 알아차리지 못함.
    }

    void AddScore()
    {
        score += 100;
    }

    void MinusScore()
    {
        score -= 100;
    }
}
