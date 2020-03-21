using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Manages an enemy object

    public Rigidbody2D rigidBody;

    // *** Movement
    public float walkSpeed; // How fast the enemy walks
    private Vector3 walkDirection; // The direction the enemy walks in
    

    // *** Animations
    public Animator animate;

    // *** Behaviours
    public float chaseDistance; // The distance to the player that triggers the chase
    public int healthPoints = 200;
    public GameObject deathSprite;
    public GameObject hitParticle;

    // *** For ranged enemies
    public bool isRanged; // Is the enemy ranged
    public Transform bulletPoint; // The place where the bullet originates from
    public GameObject bullet;  // The bullet object
    public float fireRange; // The range from where the enemy shoots from
    public float fireRate; // The rate of fire 
    private float fireRateCounter; // Keeps track of firing rate

    public SpriteRenderer spriteBody; // The enemy sprite's body

    // *** Hurt effects
    private float hitTime = .2f; // How long the hit effect lasts
    private float hitCounter; // Countdown timer of hit

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (spriteBody.isVisible && PlayerController.player.gameObject.activeInHierarchy) // If the spriteBody is not visible then the enemy behaviours are not performed
        {   // Also checks if the player is still in hierarchy or not
        // Compares position of enemy and player to chaseDistance (is Player in range?)
        if (Vector3.Distance(transform.position, PlayerController.player.transform.position) < chaseDistance)
        {
            walkDirection = PlayerController.player.transform.position - transform.position;
            if (PlayerController.player.transform.position.x < transform.position.x) // Face based on the position of the player
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        else
        {
            walkDirection = Vector3.zero; // Reset to zero if player is out of range
        }



        walkDirection.Normalize(); // Make walkspeed consistent even if walking diagonally
        rigidBody.velocity = walkDirection * walkSpeed;

        // *** For ranged enemies
        if (isRanged == true && Vector3.Distance(transform.position, PlayerController.player.transform.position) < fireRange) // Checks if the enemy pos and player pos is less than fireRange
        {
            fireRateCounter = fireRateCounter - Time.deltaTime; // Count backwards

            if (fireRateCounter <= 0) // Reset the counter if it gets to zero or less
            {
                fireRateCounter = fireRate;
                Instantiate(bullet, bulletPoint.position, bulletPoint.rotation); // Create a new bullet at the bulletPoint
            }
        }

        // ** Manages hurt effects for enemies
        if (hitCounter > 0)
            {
                hitCounter = hitCounter - Time.deltaTime;
                if (hitCounter <= 0)
                {
                    spriteBody.color = new Color(1f, 1f, 1f, 1f);
                }

            }


        // *** Animations
        if (walkDirection != Vector3.zero) // Sets the animation to walking if the enemy is walking or not
        {
            animate.SetBool("isWalking", true);
        }
        else
        {
            animate.SetBool("isWalking", false);
        }


    } else
        {
            rigidBody.velocity = Vector2.zero; // Stops the enemy from moving
        }

    }

    public void HitEnemy(int bulletDamage) // Executes when the player hits an enemy
    {
        healthPoints = healthPoints - bulletDamage;
        spriteBody.color = new Color(0.87f, 0.27f, 0.27f, 1f); // Add a hurt effect
        hitCounter = hitTime; // Start the counter which will be used to tell how long the effect lasts
        Instantiate(hitParticle, transform.position, transform.rotation); // Create a hit particle 

        if (healthPoints <= 0) // Remove the enemy after hp is <= 0
        {
            Destroy(gameObject);
            GameObject obj = Instantiate(deathSprite, transform.position, transform.rotation); // Create a death sprite
            if (PlayerController.player.transform.position.x < transform.position.x) // Make the death sprite face based on the position of the player
            {
                obj.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                obj.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
