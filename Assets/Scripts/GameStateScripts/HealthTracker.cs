using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int LASER_DAMAGE = 10;

    [SerializeField] AudioSource deathSound;

    void Start()
    {
        SetHealth();
        deathSound = GetComponent<AudioSource>();
    }

    private void ApplyDamage(int damage)
    {
        health -= damage;
        PersistData.Instance.SetScore(PersistData.Instance.GetScore() + 10);

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

    private void SetHealth()
    {
        int difficulty = PlayerPrefs.GetInt("Difficulty");
        if (difficulty == 0)
        {
            health = 100;
        }
        else if (difficulty == 1)
        {
            this.health = 200;
        }
        else if ( difficulty == 2)
        {
            this.health = 300;
        }
    }
}
