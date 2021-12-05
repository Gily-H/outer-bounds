using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int LASER_DAMAGE = 10;
    [SerializeField] AudioSource deathSound;

    void Start()
    {
        health = PersistData.Instance.GetPlayerHealth();
        deathSound = GetComponent<AudioSource>();
    }

    private void ApplyDamage(int damage)
    {
        health -= damage;
        PersistData.Instance.SetPlayerHealth(health);
        PersistData.Instance.SetScore(PersistData.Instance.GetScore() - 2);

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
        return PersistData.Instance.GetPlayerHealth();
    }
}
