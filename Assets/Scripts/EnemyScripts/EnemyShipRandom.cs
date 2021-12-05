using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShipRandom : MonoBehaviour
{
    [SerializeField] GameObject enemyLaserSpawner;
    [SerializeField] Transform enemyFirePoint;
    private float fireRate;
    private float timeTillNextFire;

    [SerializeField] Text enemyHealthText;
    [SerializeField] Transform targetPlayer;
    [SerializeField] Vector3 direction;
    [SerializeField] float rotationAngle;

    [SerializeField] Rigidbody2D enemyBody;
    [SerializeField] Vector2 movement;
    [SerializeField] float timer;
    [SerializeField] float directionTimer = 1.0f;
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        if (enemyBody == null)
        {
            enemyBody = GetComponent<Rigidbody2D>();
        }
        enemyLaserSpawner = GameObject.FindGameObjectWithTag("EnemyLaserSpawner");
        enemyHealthText = GameObject.Find("EnemyHealth").GetComponent<Text>();

        SetFireRate();
        timeTillNextFire = Time.time;
        timer = 0.5f;
    }

    private void Update()
    {
        direction = targetPlayer.position - transform.position;
        rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemyBody.rotation = rotationAngle;

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

    private void SetFireRate()
    {
        int difficulty = PlayerPrefs.GetInt("Difficulty");

        if (difficulty == 0)
        {
            this.fireRate = 1f;
        }
        else if (difficulty == 1 || difficulty == 2)
        {
            this.fireRate = 0.5f;
        }
    }
}
