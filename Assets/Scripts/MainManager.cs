using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public string playerName;
    public string highScoreName;
    public int highScore;
    public bool firstLoad = true;
    // Start is called before the first frame update
    private void Start()
    {
        LoadScore();
        MenuManager menuManager = GameObject.Find("/Canvas").GetComponent<MenuManager>();
        menuManager.SetStartData(playerName, highScoreName, highScore);
    }
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreName = playerName;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string highScoreName;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savefile.json");

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }
}
