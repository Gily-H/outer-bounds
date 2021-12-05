using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int laserDamage;
    [SerializeField] AudioSource deathSound;

    void Start()
    {
        SetLaserDamage();
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
        ApplyDamage(laserDamage);
    }

    public int GetHealth()
    {
        return PersistData.Instance.GetPlayerHealth();
    }

    private void SetLaserDamage()
    {
        int difficulty = PlayerPrefs.GetInt("Difficulty");

        if (difficulty == 0 || difficulty == 1)
        {
            this.laserDamage = 10;
        }
        else if (difficulty == 2)
        {
            this.laserDamage = 20;
        }
    }
}
