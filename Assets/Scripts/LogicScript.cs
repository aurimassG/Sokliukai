using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    [Header("Component")]
    public Text timerText;
    public Text endText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    public int score = 0;
    public Text scoreText;
    public Text scoreText2;
    public bool end = false;
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        SetTimerText();
        if (end == true)
        {
            enabled = false;
        }
    }
    private void SetTimerText()
    {
        timerText.text = "Time: " + currentTime.ToString("0.0");
    }
    public void Stop()
    {
        end = true;
    }
    public void SetEndText()
    {
        endText.text = "Total " + timerText.text;
    }
    public void StartingScore()
    {
        scoreText.text = "Score: 0";
    }

    public void addScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }

    public void computeScore()
    {
        scoreText.text = "";
        scoreText2.text = "Total Score: " + score.ToString();
    }
}
