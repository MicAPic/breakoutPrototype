using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class UIMainMenu : MonoBehaviour
{
    public Rigidbody ball;
    
    // Start is called before the first frame update
    void Start()
    {
        var randomDirection = Random.Range(-1.0f, 1.0f);
        var forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();
        
        ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
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
