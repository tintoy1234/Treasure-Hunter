using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scene : MonoBehaviour
{
    //UI management
    public GameObject explo;
    public GameObject motivation;
    public GameObject button;
    public bool go;

    //perso speed control
    public Action1 ac;
    public pausescript ps;

    //music
    public AudioSource musicstart;
    public AudioSource ambiancemusic;

    //cam et fade
    public Camera Main;
    public Camera start;
    public Image imageNoir;
    bool again = false;
    void Start()
    {
        motivation.SetActive(false);
        explo.SetActive(false);
        go = false;

        ambiancemusic.Stop();
        musicstart.Play();

        imageNoir.enabled = false;
        imageNoir.GetComponent<Image>();
        ac.enabled = false;
        ps.enabled = false;
    }

    public void Play()
    {
        musicstart.Stop();
        go = true;
        ac.enabled = true;
        ps.enabled = true;
        imageNoir.enabled = true;
        StartCoroutine(FadeImage(true));
    }

    public void Update()
    {
        if (go)
        {
            ambiancemusic.Play();
        }
        if (again)
        {
            motivation.SetActive(true);
            explo.SetActive(true);
            //StartCoroutine(FadeImage(false));
        }
    }
    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                imageNoir.color = new Color(0, 0, 0, i);
                yield return null;
            }
            again = true;
            Main.enabled = true;
            start.enabled = false;
        }
        if (again)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                imageNoir.color = new Color(0, 0, 0, i);
                yield return null;
            }
            button.SetActive(false);
        }
    }
}
