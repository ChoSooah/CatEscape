using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] private GameObject PlusItem1;
    [SerializeField] private GameObject PlusItem2;
    [SerializeField] private GameObject MinusItem1;

    public bool isMake = true;
    float span = 1.0f;
    float delta = 0;

    void Start()
    {
        TimeController.onEnd += MakeFalse;
        ActiveController.onReset += MakeTrue;
    }

    void Update()
    {
        if (isMake)
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;
                int px = UnityEngine.Random.Range(-6, 7);
                int randomNum = UnityEngine.Random.Range(0, 3); //0 이상 3 미만 정수

                switch (randomNum)
                {
                    case 0:
                        GameObject plus1 = Instantiate(PlusItem1); //오브젝트 생성
                        plus1.transform.position = new Vector3(px, 7, 0); //위치 설정
                        break;
                    case 1:
                        GameObject plus2 = Instantiate(PlusItem2); //오브젝트 생성
                        plus2.transform.position = new Vector3(px, 7, 0); //위치 설정
                        break;
                    case 2:
                        GameObject minus1 = Instantiate(MinusItem1);
                        minus1.transform.position = new Vector3(px, 7, 0);
                        break;
                    default:
                        Debug.Log("에러!");
                        break;
                }
            }
        }
    }

    void MakeTrue()
    {
        isMake = true;
        Debug.Log("true");
    }

    void MakeFalse()
    {
        isMake = false;
        Debug.Log("false");
    }
}
