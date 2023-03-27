using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    public int score;
    public Text scoreText;
    public Text scoreText2;

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
