using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootting : MonoBehaviour
{
    Rigidbody RB;
    public int speed = 40;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 Dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        RB.MovePosition(transform.position + Dir.normalized * Time.deltaTime * speed);
    }

  void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Chest")&& Input.GetKeyDown(KeyCode.A))
        {
            speed = 0;
            StartCoroutine(cameraduration());
        }
        IEnumerator cameraduration()
        {
            yield return new WaitForSeconds(2);
            speed = 40;
        }
    }
}
