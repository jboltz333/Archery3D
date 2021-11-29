using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    // If we won a game, we will reset this value to however long it took
    public float winningTime = 200;

    private int targetsLeft = 20;
    private float bestTime = 0;
    private Text targetsLeftText;
    private Text bestTimeText;

    void Start()
    {
        targetsLeftText = GameObject.Find("Text_PlayGame_TargetsLeft").GetComponent<Text>();
        bestTimeText = GameObject.Find("Text_PlayGame_BestTime").GetComponent<Text>();

        // Display how many targets we have left and what our best time is so far
        targetsLeftText.text = "Targets Left: " + 20;
        bestTimeText.text = "Best Time: " + System.Math.Round(bestTime, 1).ToString();
    }

    // Whenever a target is hit, display to the user the number of targets left
    public void DecreaseTargetCount()
    {
        targetsLeft--;
        targetsLeftText.text = "Targets Left: " + targetsLeft.ToString();
    }

    public int GetTargetCount()
    {
        return targetsLeft;
    }

    public float GetBestTime()
    {
        return bestTime;
    }

    // If we don't know whether a new time is a best time, use this method
    public void SetBestTime()
    {
        if (winningTime > bestTime)
        {
            bestTime = winningTime;
            bestTimeText.text = "Best Time: " + System.Math.Round(bestTime, 1).ToString();
        }
    }

    // If we already know its a best time, call this method
    public void SetBestTime(int time)
    {
        bestTime = time;
    }
}
