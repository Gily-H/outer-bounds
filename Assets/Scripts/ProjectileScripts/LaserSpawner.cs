using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioSource shootLaserSound;

    void Start()
    {
        if (shootLaserSound == null)
        {
            shootLaserSound = GetComponent<AudioSource>();
        }
    }

    public void Spawn(Vector3 firePosition, Quaternion rotation)
    {
        // instantiate a laser with the spawn location
        Instantiate(laserPrefab, firePosition, Quaternion.identity);

        // player laser firing sound effect
        AudioSource.PlayClipAtPoint(shootLaserSound.clip, transform.position);
    }
}
