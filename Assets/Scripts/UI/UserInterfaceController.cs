using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Access UI elements of Unity

public class UserInterfaceController : MonoBehaviour
{
    // Creates a UIcontroller and references UI elements which are used in other scripts

    public static UserInterfaceController UIcontroller;

    // The HP Bar properties
    public Slider HPBar;
    public Text HPText;

    // The Shield properties
    public Slider shieldBar;
    public Text shieldText;

    // Screen when the player is dead
    public GameObject deathUI;

    public void Awake()
    {
        UIcontroller = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
