using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    float remTime; //* 남은 시간
    public float maxTime; //* 시간 최대치
    public static event Action onEnd;

    [SerializeField] private Slider TimeSlider;

    void Start()
    {
        ResetTime(30.0f);
    }

    void Update()
    {
        this.remTime -= Time.deltaTime;
        SetnowTime();
        if (remTime <= 0)
        {
            onEnd?.Invoke();
        }
    }

    void ResetTime(float time) //*시간 설정
    {
        maxTime = time;
        remTime = maxTime;
    }

    void SetnowTime()
    {
        TimeSlider.value = remTime / maxTime;
    }
}
