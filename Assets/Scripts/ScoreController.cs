using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private int score = 0;

    public void AddScore(int newScore)
    {
    	score += newScore;
    	DisplayScore();
    }

    void DisplayScore()
    {
        var scoreText = GameObject.FindGameObjectsWithTag("Score")[0];
        scoreText.GetComponent<Text>().text = score.ToString();
    }
}
