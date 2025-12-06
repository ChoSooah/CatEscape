using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        //왼쪽 화살표가 눌렸을 때
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-2, 0, 0); //왼쪽으로 1만큼 움직인다.
        }
        //오른쪽 화살표가 눌렸을 때
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(2, 0, 0); //오른쪽으로 1만큼 움직인다.
        }
    }
}
