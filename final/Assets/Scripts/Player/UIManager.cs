using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnPlay(){
        SceneManager.LoadScene("Level");
    }
    public void OnQuit(){
        Application.Quit();
    }
    public void OnCommands(){
        SceneManager.LoadScene("Commands");
    }
    public void OnMainMenu(){
        Debug.Log("test");
        SceneManager.LoadScene("MainScreen");
    }
}
