using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float score = 3f;
    public Text scoreText;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore(float value)
    {
        score += value;
        if (score >= 4.5f) score = 4.5f;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString("0.00");
        }

        if (score <= 0)
        {
            score = 0;
            if (gameManager.dateCount[0] == 9)
            {
                SceneManager.LoadScene("Over1");
            }
            else if (gameManager.dateCount[0] == 10 && gameManager.dateCount[1] < 27)
            {
                SceneManager.LoadScene("Over2");
            }
            else if (gameManager.dateCount[0] == 11 || (gameManager.dateCount[0] == 10 && 26 < gameManager.dateCount[1]))
            {
                SceneManager.LoadScene("Over3");
            }
            else
            {
                SceneManager.LoadScene("Over4");
            }
        }
    }
}