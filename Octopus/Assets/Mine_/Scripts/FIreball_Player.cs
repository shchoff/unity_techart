using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreball_Player : MonoBehaviour
{
    public float speed;
    public GameObject Enemy;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Destroy(gameObject, .1f);
        }
    }



}
