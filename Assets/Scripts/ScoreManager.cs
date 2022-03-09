using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string playerName = "AAA";
    public int highScore;
    // public string highScorePlayer = "AAA";
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable] 
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveScore(int newScore)
    {
        SaveData data = new SaveData
        {
            name = playerName,
            score = newScore
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/" + playerName + ".json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/" + playerName + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.name;
            highScore = data.score;
        }
        else
        {
            SaveScore(0);
            highScore = 0;
        }
    }
}
