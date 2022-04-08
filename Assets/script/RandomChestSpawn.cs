using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChestSpawn : MonoBehaviour
{
    Vector3 randomPosition;
    public bool Spawn;
    public GameObject Chest;
    public int checkchest;
    void Start()
    {
        Spawn = true;
    }
    void Update()
    {
        randomPosition = new Vector3(Random.Range(17.5f, -37.5f), -1, Random.Range(16.8f, -25));
        checkchest = GameObject.FindGameObjectsWithTag("Chest").Length;
        ChestSpawn();
        if (checkchest >= 9)
        {
            Spawn = false;
        }
    }
    void ChestSpawn()
    {
        if (Spawn)
        {
            Instantiate(Chest, randomPosition, Quaternion.identity);
        }
    }
}
