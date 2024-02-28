using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0; 
    public Text scoreText; 
    public GameObject GameOver; 

    public void addScore() 
    { 
        score++; 
        scoreText.text = score.ToString(); 
    }

    public void restartGame() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        score = 0; 
        scoreText.text = score.ToString();
    }

    public void gameOver() 
    { 
        GameOver.SetActive(true); 
    }

}
