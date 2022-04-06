using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe_Durability : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public int currentchest;

    GameObject currentChest;
    public bool chestTouched = false;

    //camera management
    public bool ZoomActive;
    public float speed;
    public Camera Cam;


    public AudioSource helpsound;
    //script management
    public Exploration_Progression EP;
    public Pickaxe_Setup_Slider healthbar;

    public GameObject loose;
    public GameObject Win;

    void Start()
    {
        //camera
        Cam = Camera.main;
        loose.SetActive(false);

        currentHealth = maxHealth;
        currentchest = 0;

        //script setup
        healthbar.SetMaxHealth(maxHealth);
        EP.SetMaxChest(currentchest);

        Win.SetActive(false);
        helpsound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Dead");
            loose.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {

            if (chestTouched)
            {
                ZoomActive = true;
                ChestLoot(1);
                Destroy(currentChest);
                chestTouched = false;
            }
            else
            {
                takedamage(1);
            }
        }
        if(currentchest == 10)
        {
            Win.SetActive(true);
        }
        

    }
    void OnTriggerEnter(Collider other)
    {
        currentChest = other.gameObject;
        if (currentChest.CompareTag("Chest"))
        {
            chestTouched = true;
        }
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            
           if (other.gameObject.CompareTag("Chest"))
            {
                ZoomActive = true;
                ChestLoot(1);
                Destroy(other.gameObject);
            }
            else
            {
                takedamage(1);
            }

        }
        */
    }

    void OnTriggerExit(Collider other)
    {
        chestTouched = false;
    }

    void takedamage(int damage)
    {
        currentHealth -= damage;
        healthbar.Sethealth(currentHealth);
    }
    void ChestLoot(int Catch)
    {
        currentchest += Catch;
        EP.SetChest(currentchest);
    }
    public void LateUpdate()
    {
        if (ZoomActive)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,5, speed);
            StartCoroutine(cameraduration());
        }
    }
    IEnumerator cameraduration()
        {
        yield return new WaitForSeconds(2);
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 10, speed);
        ZoomActive = false;
    }
}
