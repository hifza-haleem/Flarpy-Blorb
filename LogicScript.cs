using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public float scoreInterval = 1.0f; 
    private float timer = 0;
    private BirdScript bird;

    void Start()
    {
        GameObject birdGameObject = GameObject.FindGameObjectWithTag("Player");
        if (birdGameObject != null)
        {
            bird = birdGameObject.GetComponent<BirdScript>();
        }
        else
        {
            Debug.LogError("Bird GameObject with tag 'Player' not found.");
        }
    }

    void Update()
    {
        if (bird != null && bird.birdAlive)
        {
            timer += Time.deltaTime;
            if (timer >= scoreInterval)
            {
                addScore(1);
                timer = 0;
            }
        }
    }

    public void addScore(int scoreToAdd = 1)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
