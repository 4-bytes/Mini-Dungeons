using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string levelName;
    // Handles Main Menu UI
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame() // Load the level
    {
        SceneManager.LoadScene(levelName);

    }

    public void exitGame() // Quit the game
    {
        Application.Quit();
    }

    public void help() // Load the help scene
    {
        SceneManager.LoadScene("Help");
    }
}
