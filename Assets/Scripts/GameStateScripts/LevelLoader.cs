using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject enemyShip;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Player");
        enemyShip = GameObject.FindGameObjectWithTag("Enemy");
        level = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (playerShip == null)
        {
            ReloadLevel();
        }
        else if (enemyShip == null)
        {
            AdvanceLevel();
        }
    }

    public void AdvanceLevel()
    {
        if (level < 7)
        {
            SceneManager.LoadScene(level + 1);
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(level);
    }
}
