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
        playerHealthText = GameObject.Find("PlayerHealth").GetComponent<Text>();
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
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) 
        {
            MoveVertical();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveHorizontal();
        }
    }

    private void FixedUpdate()
    {
        DisplayPlayerHealth();
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

    private void MoveVertical()
    {
        playerBody.velocity = new Vector2(playerBody.velocity.x, vMovement * speed);

    }

    private void MoveHorizontal()
    {
        playerBody.velocity = new Vector2(hMovement * speed, playerBody.velocity.y);

    }

    private void FireLaser()
    {
        firePoint = GameObject.Find("PlayerFirePoint").transform;
        laserSpawner.GetComponent<LaserSpawner>().Spawn(firePoint.position, firePoint.rotation);
    }

    private void DisplayPlayerHealth()
    {
        playerHealthText.text = "Player: " + gameObject.GetComponent<PlayerHealth>().GetHealth() + "%";
    }

    public int GetHealth()
    {
        return gameObject.GetComponent<PlayerHealth>().GetHealth();
    }

    public bool GetIsFacingRight()
    {
        return this.isFacingRight;
    }
}
