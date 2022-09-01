using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject title;
    public GameObject backgroundCanvas;
    public TextMeshProUGUI scoreCount;

    public Button restartButton;

    public bool isGameActive;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        MainManager.instance.SetHighScore(score);
        SceneManager.LoadScene(0);
    }

    public void IncrementScore(int score)
    {
        this.score = score;
        scoreCount.text = "Score: " + this.score;
    }
}
