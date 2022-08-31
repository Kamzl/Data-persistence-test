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

    public Button startButton;
    public Button restartButton;

    public bool isGameActive;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartGame()
    {
        title.SetActive(false);
        backgroundCanvas.SetActive(false);
        scoreCount.gameObject.SetActive(true);
        isGameActive = true;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        backgroundCanvas.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void IncrementScore(int score)
    {
        this.score = score;
        scoreCount.text = "Score: " + this.score;
    }
}
