using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Racket : MonoBehaviour
{
    public float speed = 50;
    public string axis = "Vertical";

    void FixedUpdate ()
    {
        float v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
