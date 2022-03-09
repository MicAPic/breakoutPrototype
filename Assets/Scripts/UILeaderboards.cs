using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILeaderboards : MonoBehaviour
{
    public TextMeshProUGUI playerList;
    private int maxPlayerNum = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, int> players = new Dictionary<string, int>();

        foreach (var fileName in Directory.EnumerateFiles(Application.persistentDataPath, "*.json"))
        {
            ScoreManager.Instance.playerName = fileName.Substring(Application.persistentDataPath.Length + 1, 3);
            ScoreManager.Instance.LoadScore();
            
            players.Add(ScoreManager.Instance.playerName, ScoreManager.Instance.highScore);
        }
        var sortedPlayers = from entry in players orderby entry.Value select entry;

        int place = 1;
        playerList.text = "";
        foreach (var player in sortedPlayers.Reverse())
        {
            playerList.text += $"{place} : {player.Key} : {player.Value}\n";
            place++;
            if (place > maxPlayerNum)
            {
                break;
            }
        }

    }

    public void SceneStart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
