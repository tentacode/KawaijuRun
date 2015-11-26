using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private int score = 0;
    private MainCharacterController mainCharacterController;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        mainCharacterController = player.GetComponent<MainCharacterController>();
        
        var highScoreText = GameObject.FindGameObjectsWithTag("HighScore")[0];
        highScoreText.GetComponent<Text>().text = "High Score " + GetHighScore();
    }

    void Update()
    {
        if (mainCharacterController.GetState() == MainCharacterController.States.Dead) {
            var scoreText = GameObject.FindGameObjectsWithTag("Score")[0];
            scoreText.GetComponent<Text>().text = "";
        }
    }

    public void AddScore(int newScore)
    {
    	score += newScore;

        if (score > GetHighScore()) {
            SetHighScore(score);
        }

    	DisplayScore();
    }

    void DisplayScore()
    {
        var scoreText = GameObject.FindGameObjectsWithTag("Score")[0];
        scoreText.GetComponent<Text>().text = score.ToString();
    }

    float GetHighScore()
    {
        return PlayerPrefs.GetFloat("highscore");
    }

    void SetHighScore(float score)
    {
        PlayerPrefs.SetFloat("highscore", score);
        PlayerPrefs.Save();
    }
}
