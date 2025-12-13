using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;

        ActiveController.onReset += Reseting;
    }

    public void GoToLeft()
    {
        float x = transform.position.x;

        if (x != -8f) // 플레이어가 좌측 끝까지 가지 않았다면
        {
            transform.Translate(-2, 0, 0); //왼쪽으로 2만큼 움직인다.
        }
    }

    public void GoToRight()
    {
        float x = transform.position.x;
        if (x != 8f) // 플레이어가 우측 끝까지 가지 않았다면
        {
            transform.Translate(2, 0, 0); //오른쪽으로 2만큼 움직인다.
        }
    }

    void Reseting()
    {
        transform.position = new Vector3(0, -3.5f, 0);
    }

}
