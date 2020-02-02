using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitch : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public void doExitGame()
    {
        Debug.Log("Let's pretend the app closed!");
        Application.Quit(); 
    }
}
