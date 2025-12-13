using TMPro;
using System;
using UnityEngine;

public class ActiveController : MonoBehaviour
{
    [SerializeField] private GameObject inGameObject;
    [SerializeField] private GameObject endGameObject;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject endScoreText;

    public static event Action onReset;

    void Start()
    {
        ArrowController.onEndDis += LoadEndUI;
    }

    void Update()
    {

    }

    void LoadEndUI()
    {
        player.SetActive(false);
        inGameObject.SetActive(false);
        endGameObject.SetActive(true);
        this.endScoreText.GetComponent<TextMeshProUGUI>().text = "최종 점수: " + GameDirector.Instance.score.ToString();
    }

    public void OnEndButton()
    {
        Application.Quit(); //빌드 파일에서만 종료되는 코드.
        Debug.Log("게임 종료.");
    }

    public void OnBackButton()
    {
        player.SetActive(true);
        inGameObject.SetActive(true);
        endGameObject.SetActive(false);
        onReset?.Invoke();
    }
}
