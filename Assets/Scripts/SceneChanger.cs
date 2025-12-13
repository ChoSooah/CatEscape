using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    /*
        public void ChangeSceneForEnd()
        {
            SceneManager.LoadScene("EndScene");
            GameDirector.Instance.sceneNumber = 2;
        }
    */

    public void ChangeSceneForGame()
    {
        SceneManager.LoadScene("GameScene");
        GameDirector.Instance.sceneNumber = 1;
    }

    public void OnGoToGameButtonClicked()
    {
        GameDirector.Instance.score = 0;
        ChangeSceneForGame();
    }
}
