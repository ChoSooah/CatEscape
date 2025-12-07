using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    public static event Action onScorePlus;
    public static event Action onScorePlusPlus;
    public static event Action onScoreMinus;

    void Start()
    {
        this.player = GameObject.Find("player");
    }

    void Update()
    {
        //프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, -0.1f, 0);

        //화면 밖으로 나오면 오브젝트를 소멸시킨다.
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //충돌판정
        Vector2 p1 = transform.position; //화살의 중심 좌표
        Vector2 p2 = this.player.transform.position; //플레이어의 중심 좌표

        Vector2 dir = p1 - p2;
        float d = dir.magnitude; //magnitude는 벡터의 크기 혹은 길이를 구할 때 사용된다.
        float r1 = 0.5f; //화살의 반지름
        float r2 = 1.0f; //플레이어의 반지름

        if (d < r1 + r2)
        {
            string objectName = gameObject.name;
            if (objectName.StartsWith("PlusItem1"))
            {
                onScorePlus?.Invoke();
            }
            else if (objectName.StartsWith("PlusItem2"))
            {
                onScorePlusPlus?.Invoke();
            }
            else if (objectName.StartsWith("MinusItem1"))
            {
                onScoreMinus?.Invoke();
            }
            //충돌한 경우는 화살을 지운다.
            Destroy(gameObject);
        }
    }
}
