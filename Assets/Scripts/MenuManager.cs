using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerName;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject restartMenu;
    [SerializeField] TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Awake()
    {
        if (MainManager.instance != null && !MainManager.instance.firstLoad)
        {
            startMenu.SetActive(false);
            restartMenu.SetActive(true);
            highScore.text = "High Score ( " + MainManager.instance.highScoreName + "): " + MainManager.instance.highScore;
            playerName.text = MainManager.instance.playerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStartData(string mainPlayerName, string highPlayerName, int highScore)
    {
        playerName.text = mainPlayerName;
        this.highScore.text = "High Score ( " + highPlayerName + "): " + highScore;
    }

    public void LoadMain()
    {
        MainManager.instance.playerName = playerName.text;
        MainManager.instance.firstLoad = false;
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        MainManager.instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
