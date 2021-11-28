using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] GameObject laserSpawner;
    [SerializeField] Transform firePoint;

    [SerializeField] Text playerHealthText;

    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] float hMovement;
    [SerializeField] float vMovement;
    [SerializeField] float speed = 10.0f;
    [SerializeField] bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        if (playerBody == null)
        {
            playerBody = GetComponent<Rigidbody2D>();
        }

        laserSpawner = GameObject.FindGameObjectWithTag("LaserSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        // get horizontal and vertical movement from input
        hMovement = Input.GetAxis("Horizontal");
        vMovement = Input.GetAxis("Vertical");
        
        // fire laser when space bar pressed
        if (Input.GetKeyDown("space"))
        {
            FireLaser();
        }

    }

    private void FixedUpdate()
    {
        DisplayPlayerHealth();
        Move();
        CheckForFlip();
    }

    // adjust sprite orientation to match movement direction
    private void CheckForFlip()
    {
        // if moving left facing right then flip, or if moving right facing left then flip
        if (hMovement < 0 && isFacingRight || hMovement > 0 && !isFacingRight)
        {
            this.transform.Rotate(0, 180, 0);
            isFacingRight = !isFacingRight;
        }
    }

    // Playership horizontal and vertical movement
    private void Move()
    {
        if (hMovement != 0)
        {
            playerBody.velocity = new Vector2(hMovement * speed, playerBody.velocity.y);
        }
        else if (vMovement != 0)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, vMovement * speed);
        }
    }

    // create and shoot laser beam
    private void FireLaser()
    {

        firePoint = GameObject.Find("PlayerFirePoint").transform;
        // get the LaserSpawner script and call the SpawnLaser method
        laserSpawner.GetComponent<LaserSpawner>().Spawn(firePoint.position, firePoint.rotation);
    }

    private void DisplayPlayerHealth()
    {
        playerHealthText.text = "Player: " + gameObject.GetComponent<HealthTracker>().GetHealth() + "%";
    }

    public int GetHealth()
    {
        return gameObject.GetComponent<HealthTracker>().GetHealth();
    }
}
