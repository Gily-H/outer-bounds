using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] AudioSource shootEnemyLaserSound;

    void Start()
    {
        if (shootEnemyLaserSound == null)
        {
            shootEnemyLaserSound = GetComponent<AudioSource>();
        }
    }

    public void Spawn(Vector3 enemyFirePosition)
    {
        Debug.Log("Spawning Laser");
        // instantiate a laser with the spawn location
        Instantiate(enemyLaserPrefab, enemyFirePosition, Quaternion.identity);

        // player laser firing sound effect
        AudioSource.PlayClipAtPoint(shootEnemyLaserSound.clip, transform.position);
    }
}
