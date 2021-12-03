using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] GameObject enemyLaserSpawner;
    [SerializeField] Transform enemyFirePoint;
    private float fireRate;
    private float timeTillNextFire;

    [SerializeField] Text enemyHealthText;

    [SerializeField] Rigidbody2D enemyBody;
    [SerializeField] Vector2 movement;
    [SerializeField] float timer;
    [SerializeField] float directionTimer = 1.0f;
    [SerializeField] float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (enemyBody == null)
        {
            enemyBody = GetComponent<Rigidbody2D>();
        }
        enemyLaserSpawner = GameObject.FindGameObjectWithTag("EnemyLaserSpawner");
        enemyHealthText = GameObject.Find("EnemyHealth").GetComponent<Text>();

        fireRate = 1f;
        timeTillNextFire = Time.time;
        timer = 0.5f;
    }

    private void Update()
    {
        if (Time.time > timeTillNextFire)
        {
            FireEnemyLaser();
        }
    }

    private void FixedUpdate()
    {
        DisplayEnemyHealth();
        SetRandomDirection();
        RandomMove();
    }

    // adjust sprite orientation to match movement direction
    private void Flip()
    {
        
            this.transform.Rotate(0, 180, 0);
    }

    // Enemy ship horizontal and vertical movement
    private void RandomMove()
    {
        enemyBody.AddForce(movement * speed);
    }

    private void SetRandomDirection()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            movement = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            timer += directionTimer;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            speed *= -1;
        }
    }

    private void FireEnemyLaser()
    {
        enemyFirePoint = GameObject.Find("EnemyFirePoint").transform;
        enemyLaserSpawner.GetComponent<EnemyLaserSpawner>().Spawn(enemyFirePoint.position);
        timeTillNextFire = Time.time + fireRate;
    }

    private void DisplayEnemyHealth()
    {
        enemyHealthText.text = "Enemy: " + gameObject.GetComponent<HealthTracker>().GetHealth() + "%";
    }

    public int GetHealth()
    {
        return gameObject.GetComponent<HealthTracker>().GetHealth();
    }
}
