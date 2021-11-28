using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int LASER_DAMAGE = 10;

    [SerializeField] AudioSource deathSound;

    void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }

    private void ApplyDamage(int damage)
    {
        health -= damage;
        
        // if ship has no hp, destroy ship
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound.clip, transform.position);
            Destroy(gameObject);
        }
    }

    public void ApplyDamage()
    {
        ApplyDamage(LASER_DAMAGE);
    }

    public int GetHealth()
    {
        return health;
    }
}
