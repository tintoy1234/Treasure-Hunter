using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action1 : MonoBehaviour
{
    public int speed = 20;
    private CharacterController characontrol;
    void Start()
    {
        characontrol = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 Dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        float magnitude = Mathf.Clamp01(Dir.magnitude) * speed;
        Dir.Normalize();

        characontrol.SimpleMove(Dir * magnitude);
    }
    private void OnTriggerStay(Collider other)
    {
        print("coffre dispo");
        if (other.gameObject.CompareTag("Chest") && Input.GetKeyDown(KeyCode.A))
        {
            print("creuse");
            speed = 0;
            StartCoroutine(cameraduration());
        }
    }
    IEnumerator cameraduration()
    {
        yield return new WaitForSeconds(2);
        speed = 20;
    }
}
