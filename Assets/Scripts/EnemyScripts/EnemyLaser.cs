using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float movement;
    private AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
        // destroy laser after 4 seconds if no collision triggered
        Destroy(gameObject, 4.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LaserMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthTracker>().ApplyDamage();
            AudioSource.PlayClipAtPoint(hitSound.clip, transform.position);
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }

    private void LaserMovement()
    {
        movement = -1 * speed * Time.deltaTime;

        // laser moves horizontally
        this.transform.Translate(movement, 0, 0);
    }
}
