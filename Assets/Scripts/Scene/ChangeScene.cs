using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// [File I/O]: Client using JsonHandler to work with File
/// Handle scene changing by Buttons
/// </summary>
public class ChangeScene : MonoBehaviour
{
    //Load Scene by sceneName
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Quite Game (From StartMenu)
    public void QuitGame()
    {
        Application.Quit();
    }

    //Quite Game (From GamePlay)
    public void QuitGameAndSaveData()
    {
        //Save data to File
        JsonHandler handler = gameObject.GetComponent<JsonHandler>();
        handler.data = new UserData();

        Farmer mainCharacterFarmer = GameObject.FindGameObjectWithTag("Player").GetComponent<Farmer>();

        handler.data.Money = mainCharacterFarmer.Money;
        handler.data.seeds = mainCharacterFarmer.seeds;

        handler.Save();

        //Quit
        Application.Quit();
    }
}
