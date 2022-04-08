using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe_Durability : MonoBehaviour
{
    //variable
    public int maxHealth = 5;
    public int currentHealth;
    public int currentchest;
    GameObject currentChest;
    public bool chestTouched = false;
    bool Anim = false;

    //camera management pour retour visuel
    public bool ZoomActive;
    public float speed;
    public int speedchild;
    Camera Cam;

    //son enfant
    AudioSource helpsound;

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
            Debug.Log("Dead");
            loose.SetActive(true);
        }

        if (Anim)
        {
            currentChest.transform.Translate(Vector3.up * speedchild * Time.deltaTime);
            if (currentChest.transform.position.y >= 1)
            {
                speedchild = 1;
            }
            if (currentChest.transform.position.y >= 2)
            {
                Anim = false;
                Destroy(currentChest);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            if (chestTouched)
            {
                speedchild = 10;
                ZoomActive = true;
                ChestLoot(1);
                if (currentHealth == maxHealth)
                {

                }
                else 
                {
                    takedamage(-1);
                }
                chestTouched = false;
                Anim = true;
                helpsound.Stop();
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
