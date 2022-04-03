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
        randomPosition = new Vector3(Random.Range(50, -50), 0, Random.Range(22, -25));
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
