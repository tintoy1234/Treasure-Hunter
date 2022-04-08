using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausescript : MonoBehaviour
{
    public GameObject pauseUI;
    bool Pausemenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausemenu)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        Pausemenu = false;
    }
    void pause()

    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        Pausemenu = true;
    }
}
