using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Sprite player1;
    [SerializeField] private Sprite player2;

    float timer = 0f;
    bool wait = false;

    void Start()
    {
        Application.targetFrameRate = 60;

        ArrowController.onScorePlus += changeSprite2;
        ArrowController.onScorePlusPlus += changeSprite2;
        ArrowController.onScoreMinus += changeSprite1;
    }

    void Update()
    {
        if (wait)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 0.3f)
        {
            GetComponent<SpriteRenderer>().sprite = player1;
            timer = 0f;
            wait = false;
        }

        //왼쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-2, 0, 0); //왼쪽으로 1만큼 움직인다.
        }
        //오른쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(2, 0, 0); //오른쪽으로 1만큼 움직인다.
        }
    }

    void changeSprite1()
    {
        GetComponent<SpriteRenderer>().sprite = player1;
        timer = 0f;
        wait = false;
    }

    void changeSprite2()
    {
        GetComponent<SpriteRenderer>().sprite = player2;
        wait = true;
    }

}
