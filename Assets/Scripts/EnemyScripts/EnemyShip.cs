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

    [SerializeField] Transform targetPlayer;
    [SerializeField] Vector3 direction;
    [SerializeField] float rotationAngle;

    [SerializeField] Rigidbody2D enemyBody;
    [SerializeField] Vector2 movement;
    [SerializeField] float timer;
    [SerializeField] float directionTimer = 1.0f;
    [SerializeField] float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // get player ship transform component
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        if (enemyBody == null)
        {
            enemyBody = GetComponent<Rigidbody2D>();
        }
        enemyLaserSpawner = GameObject.FindGameObjectWithTag("EnemyLaserSpawner");
        enemyHealthText = GameObject.Find("EnemyHealth").GetComponent<Text>();

        SetFireRate(); // how fast the enemy fires 
        timeTillNextFire = Time.time; // time between each fire
    }

    private void Update()
    {
        // distance between enemy ship and player ship
        direction = targetPlayer.position - transform.position;
        // rotate the enemy ship to face the player ship
        rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemyBody.rotation = rotationAngle;
        movement = direction.normalized;

        if (Time.time > timeTillNextFire)
        {
            FireEnemyLaser();
        }
    }

    private void FixedUpdate()
    {
        DisplayEnemyHealth();
        Chasing();
    }

    // enemy chasing player function
    private void Chasing()
    {
        enemyBody.MovePosition(transform.position + (direction * speed) * Time.deltaTime);
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
