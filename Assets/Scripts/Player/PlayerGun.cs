using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    // Handles player gun 
    [Header("Shooting: ")]
    public GameObject bulletObject; // The bullet to fire
    public Transform bulletPoint;  // The position to fire from
    public float fireRate; // The rate of fire for a weapon
    private float fireRateCounter; // Keeps track of fireRate counts


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.player.isActivated && LevelManagement.manager.isPaused == false)
        {
            if (fireRateCounter > 0)
            {
                fireRateCounter = fireRateCounter - Time.deltaTime; // Limits how many bullets can be fired
            } 
            
            else
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) // Make a bullet appear single click if left MB is pressed or holding it down
                {
                    Instantiate(bulletObject, bulletPoint.position, bulletPoint.rotation); // Create new bullet object
                    fireRateCounter = fireRate; // Reset the counter
                }
                /* if (Input.GetMouseButton(0)) // Holding down the mouse button fire multiple shots
                {
                    fireRateCounter = fireRateCounter - Time.deltaTime; // Count downwards
                    if (fireRateCounter <= 0) // When it reaches zero, fire a bullet
                    {
                        Instantiate(bulletObject, bulletPoint.position, bulletPoint.rotation); // Create a new bullet at the bulletPoint
                        fireRateCounter = fireRate; // Reset the counter
                    }
                } */
            }
        }
    }
}
