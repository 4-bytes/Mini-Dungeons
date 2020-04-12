using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Manages data between scenes
    public static DataManager data;

    public int currentHP;
    public int maxHP;
    public int currentShield;
    public int maxShield;
    public int playerCoins;

    // Start is called before the first frame update


    private void Awake()
    {
        data = this;
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadCoins()
    {
        playerCoins = PlayerPrefs.GetInt("playerCoins", 0); // Get the number of coins, default val is 0
    }
}
