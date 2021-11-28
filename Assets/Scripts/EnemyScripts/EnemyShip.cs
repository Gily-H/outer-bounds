using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] Text enemyHealthText;

    [SerializeField] Rigidbody2D enemyBody;
    [SerializeField] Vector2 movement;
    [SerializeField] float timer;
    [SerializeField] float directionTimer = 1.0f;
    [SerializeField] float speed = 5.0f;
    [SerializeField] bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        if (enemyBody == null)
        {
            enemyBody = GetComponent<Rigidbody2D>();
        }

        this.timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        SetRandomDirection();
    }

    private void FixedUpdate()
    {
        DisplayEnemyHealth();
        RandomMove();
    }

    // adjust sprite orientation to match movement direction
    private void Flip()
    {
        this.transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
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
            movement = new Vector2(Random.Range(-1.0f, 2.0f), Random.Range(-1.0f, 2.0f));
            timer += directionTimer;
        }
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
