using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime;
    private Text countdownText;

    void Start()
    {
        countdownText = GameObject.Find("Text_PlayGame_TimeLeft").GetComponent<Text>();
    }

    void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            countdownText.text = "Time Left: " + System.Math.Round(countdownTime, 1).ToString();
        }
        else
        {
            countdownTime = 0;
            countdownText.text = "Time Left: 0.0";
        }
    }
}
