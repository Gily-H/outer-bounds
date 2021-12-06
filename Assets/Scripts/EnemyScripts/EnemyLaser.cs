using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] float speed = 10.0f;
    [SerializeField] Transform targetPlayer;
    private AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        hitSound = GetComponent<AudioSource>();

        LaserMovement();
        // destroy laser after 4 seconds if no collision triggered
        Destroy(gameObject, 4.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().ApplyDamage();
            AudioSource.PlayClipAtPoint(hitSound.clip, transform.position);
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }

    private void LaserMovement()
    {
        // shoot laser in direction of player ship
        Vector2 force = (targetPlayer.position - transform.position).normalized * speed;
        bullet.velocity = new Vector2(force.x, force.y);

        // rotate bullet to face player ship
        float rotationAngle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg;
        bullet.rotation = rotationAngle;
    }
}
