using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    GameObject[] pauseMode;
    GameObject[] resumeMode;
    [SerializeField] Text pauseText;

    // Start is called before the first frame update
    void Start()
    {
        pauseMode = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        resumeMode = GameObject.FindGameObjectsWithTag("ShowWhenResumed");

        foreach (GameObject g in pauseMode)
        {
            g.SetActive(false);
        }
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        foreach (GameObject g in pauseMode)
        {
            g.SetActive(true);
        }

        foreach (GameObject g in resumeMode)
        {
            g.SetActive(false);
        }

        pauseText.text = "";
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        foreach (GameObject g in pauseMode)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in resumeMode)
        {
            g.SetActive(true);
        }

        pauseText.text = "Press \"p\" to pause";

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}