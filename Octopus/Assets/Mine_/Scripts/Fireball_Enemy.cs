using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Enemy : MonoBehaviour
{
    public float speed;
    public GameObject Player;

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
        if (collider.tag == "Player")
        {
            Destroy(gameObject, .1f);
        }
    }
}
