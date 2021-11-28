using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] PlayerShip playerShip;
    [SerializeField] bool laserDirection;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float movement;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
        laserDirection = playerShip.GetIsFacingRight();
        // destroy laser after 2 seconds if no collision triggered
        Destroy(gameObject, 4.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LaserMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthTracker>().ApplyDamage();
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }

    private void LaserMovement()
    {
        movement = speed * Time.deltaTime;
        
        if (!laserDirection)
        {
            // shoot left when ship facing left
            movement *= -1;
        }

        // laser moves horizontally
        this.transform.Translate(movement, 0, 0);
    }
}
