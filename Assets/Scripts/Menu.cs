using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // start game 
    public void StartGame()
    {
        Debug.Log("Level start");
    }

    // load options
    public void ShowOptions()
    {
        Debug.Log("Loading options");
    }

    // quit games
    public void QuitGame()
    {
        Application.Quit();
    }


}
