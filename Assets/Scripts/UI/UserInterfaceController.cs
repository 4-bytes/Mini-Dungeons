using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Access UI elements of Unity
using UnityEngine.SceneManagement;
public class UserInterfaceController : MonoBehaviour
{
    // Creates a UIcontroller and references UI elements which are used in other scripts

    public static UserInterfaceController UIcontroller;

    public string mainMenu;
    public string newGame;

    // *** Main User Interface
    public Image pauseButton;
    // The HP Bar properties
    public Slider HPBar;
    public Text HPText;
    // The Shield properties
    public Slider shieldBar;
    public Text shieldText;
    // Player coin
    public Text playerCoins;
    // Gun details
    public Image currentGunImage;
    public Text currentGunText;

    // Minimap
    public GameObject minimap;
    public GameObject minimapBackground;

    // Screen when the player is dead
    public GameObject deathUI;

    // Screen when game is paused
    public GameObject pauseUI;

    // Fading image background
    public Image fadeBackground;
    public float fadeTime;
    private bool fadeIn;
    private bool fadeOut;

    
    public void Awake()
    {
        UIcontroller = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeOut = true; // At start, make fade out from black background
        fadeIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut == true)
        {
            fadeBackground.color = new Color(fadeBackground.color.r, fadeBackground.color.g, fadeBackground.color.b, Mathf.MoveTowards(fadeBackground.color.a, 0f, fadeTime * Time.deltaTime));
            
            if (fadeBackground.color.a == 0f)
            {
                fadeOut = false; // Set to false once the background has faded
            }
        }

        if (fadeIn == true)
        {
            fadeBackground.color = new Color(fadeBackground.color.r, fadeBackground.color.g, fadeBackground.color.b, Mathf.MoveTowards(fadeBackground.color.a, 1f, fadeTime * Time.deltaTime));
            
            if (fadeBackground.color.a == 1f)
            {
                fadeIn = false; 
            }

        }
    }

    public void loadNewGame() // Loads new game
    {
        Time.timeScale = 1f; // Reset time back to normal when new game is loaded

        SceneManager.LoadScene(newGame);
    }

    public void exitGame() // Exits back to main menu
    {
        Time.timeScale = 1f; 

        SceneManager.LoadScene("MainMenu");
    }

    public void resumeGame() // Resumes game from pause state
    {
        LevelManagement.manager.pauseLevel();
    }

    public void startFadeIn() // Starts the fading in animation
    {
        fadeIn = true;
        fadeOut = false;
    }
}
