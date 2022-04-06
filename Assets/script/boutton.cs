using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class boutton : MonoBehaviour
{
    public GameObject tips;
    public Camera Main;
    public Camera start;
    private void Start()
    {
        tips.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quitté");
    }
    public void Tips()
    {
        tips.SetActive(true);
    }
    public void Back()
    {
        tips.SetActive(false);
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

