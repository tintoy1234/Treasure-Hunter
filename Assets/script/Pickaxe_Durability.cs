using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe_Durability : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public int currentchest;


    //camera management
    public bool ZoomActive;
    public float speed;
    public Camera Cam;

    //script management
    public Exploration_Progression EP;
    public Pickaxe_Setup_Slider healthbar;

    void Start()
    {
        //camera
        Cam = Camera.main;

        currentHealth = maxHealth;
        currentchest = 0;

        //script setup
        healthbar.SetMaxHealth(maxHealth);
        EP.SetMaxChest(currentchest);
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Dead");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Chest")&& Input.GetKeyDown(KeyCode.A))
        {
            ZoomActive = true;
            ChestLoot(1);
            Destroy(other.gameObject);
        }
        if (!other.gameObject.CompareTag("Chest") && Input.GetKeyDown(KeyCode.A))
        {
            takedamage(1);
        }
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
    /*void chestreward(int nodamage)
      {
          currentHealth += nodamage;
          healthbar.Sethealth(currentHealth);
      }*/
}
