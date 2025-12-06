using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefabPlus;
    [SerializeField] private GameObject arrowPrefabMinus;
    float span = 1.0f;
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            int px = Random.Range(-6, 7);
            int randomNum = Random.Range(0, 2); //0 이상 2 미만 정수

            switch (randomNum)
            {
                case 0:
                    GameObject plus = Instantiate(arrowPrefabPlus); //오브젝트 생성
                    plus.transform.position = new Vector3(px, 7, 0); //위치 설정
                    break;
                case 1:
                    GameObject minus = Instantiate(arrowPrefabMinus);
                    minus.transform.position = new Vector3(px, 7, 0);
                    break;
                default:
                    Debug.Log("에러!");
                    break;
            }
        }
    }
}
