using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_RacketRR : MonoBehaviour
{
    public float speed = 50;
    public string axis = "Vertical2";

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical2");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}

