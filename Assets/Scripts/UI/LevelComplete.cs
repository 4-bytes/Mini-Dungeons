using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string levelName;
    public string levelStage;

    public float waitCountdown = 3f;
    public GameObject continueButton;
    public GameObject exitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitCountdown > 0) // Add a short countdown before displaying buttons
        {
            waitCountdown = waitCountdown - Time.deltaTime; 
            if (waitCountdown <= 0)
            {
                continueButton.SetActive(true);
                exitButton.SetActive(true);
            }
            else
            {
                if (Input.anyKeyDown)
                {
                    continueLevel();
                }
            }
        }
    }

    public void continueLevel() // Load the level
    {
        SceneManager.LoadScene(levelName);

    }

    public void exitLevel() // Load the level
    {
        SceneManager.LoadScene("MainMenu");

    }
}
