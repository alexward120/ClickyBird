using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int playerScore = 0;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource point;
    public AudioSource gameOverSound;
    public BirdScript bird;
    private void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int score)
    {
        if (bird.birdIsAlive)
        {
            playerScore += score;
            scoreText.text = playerScore.ToString();
            point.Play();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Debug.Log(PlayerPrefs.GetInt("HighScore").ToString());
    }
    public void gameOver()
    {
        gameOverSound.Play();
        int currHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (playerScore > currHighScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            currHighScore = playerScore;
            highScoreText.text = "High Score: " + currHighScore.ToString();
        }
        gameOverScreen.SetActive(true);
    }
    public void MoveToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
