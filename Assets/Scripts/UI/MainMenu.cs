using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // The level to play
    public string levelName;

    // For displaying screens in Main Menu
    public GameObject mainScreen;
    public GameObject helpScreen;

    // Buttons for turning on/off sound effects
    public GameObject soundActiveButton;
    public GameObject soundInactiveButton;

    public new AudioSource audio;
    // Handles Main Menu UI
    // Start is called before the first frame update
    void Start()
    {
        if (AudioListener.volume == 0) // If the volume was already muted then display the correct icon
        {
            soundActiveButton.SetActive(false);
            soundInactiveButton.SetActive(true);
        }
        else
        {
            soundActiveButton.SetActive(true);
            soundInactiveButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newGame() // Load the level
    {
        SceneManager.LoadScene(levelName);

    }

    public void soundTrigger() // Turn off/on sound effects
    {
        if (AudioListener.volume == 1) // If the audio source is already running then turn it off
        {
            audio.enabled = false;
            AudioListener.volume = 0; // Set global volume to 0
            soundActiveButton.SetActive(false);
            soundInactiveButton.SetActive(true);
        }
        else
        {
            audio.enabled = true;
            AudioListener.volume = 1;
            soundActiveButton.SetActive(true);
            soundInactiveButton.SetActive(false);
        }


    }

    public void exitHelpScreen() // When the player presses back button
    {
        helpScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void exitGame() // Quit the game
    {
        Application.Quit();
    }

    public void help() // Activate the help screen and deactivate the main screen
    {
        mainScreen.SetActive(false);
        helpScreen.SetActive(true);
    }
}
