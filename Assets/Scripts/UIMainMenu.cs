using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class UIMainMenu : MonoBehaviour
{
    public Rigidbody ball;
    public TMP_InputField nameInputField; 
    
    // Start is called before the first frame update
    void Start()
    {
        var randomDirection = Random.Range(-1.0f, 1.0f);
        var forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();
        
        ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
        
        Debug.Log(Application.persistentDataPath);
        
    }

    public void WriteName()
    {
        ScoreManager.Instance.playerName = nameInputField.text.ToUpper();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("main");
    }

    public void GameQuit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
   
}
