using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString(); //scroreText.text has access to only the text part of the UI componenet
    }

    public void scoreHit(int scoreIncrease)
    {
        scoreIncrease = scoreIncrease + scoreIncrease;
        scoreText.text = scoreIncrease.ToString();
    }
}
