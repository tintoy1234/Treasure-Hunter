using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action1 : MonoBehaviour
{
    public float turnspeed = 0.5f;
    public int speed;
    private CharacterController characontrol;
    bool speedlock;
    void Start()
    {
        speedlock = false;
        characontrol = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 Dir = new Vector3(Input.GetAxisRaw("Horizontal")* Time.deltaTime * turnspeed, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * turnspeed);
        Dir.Normalize();
        float magnitude = Mathf.Clamp01(Dir.magnitude) * speed;
        characontrol.SimpleMove(Dir * magnitude);

        if(Dir != Vector3.zero)
        {
            transform.forward = Dir;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (speedlock)
            {
                print("creuse");
                StartCoroutine(cameraduration());
                speedlock = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        print("coffre dispo");
        if (other.gameObject.CompareTag("Chest"))
        {
            speedlock = true;
        }
    }
    IEnumerator cameraduration()
    {
        speed = 0;
        yield return new WaitForSeconds(2);
        speed = 15;
    }
}
