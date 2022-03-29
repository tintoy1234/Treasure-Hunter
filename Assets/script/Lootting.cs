using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootting : MonoBehaviour
{
    Rigidbody RB;
    public int speed = 5;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 Dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        RB.MovePosition(transform.position + Dir.normalized * Time.deltaTime * speed);

        Debug.Log(speed);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            if (Input.GetKey(KeyCode.A))
            {
                Destroy(other.gameObject);
                
            }
        }
    }
}
