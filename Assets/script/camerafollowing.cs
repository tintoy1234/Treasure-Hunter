using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollowing : MonoBehaviour
{
    public Transform player;
    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        transform.position = player.transform.position + new Vector3(58, 45, -65);
    }
}
