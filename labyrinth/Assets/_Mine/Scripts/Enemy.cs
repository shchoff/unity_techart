using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject Rocket;
    public float dist;
    NavMeshAgent nav;
    public float radius = 18;
    public float hp = 100;

    void Start()
    {
        nav = GetComponent<NavMeshAgent> ();
    }

    void Update()
    {
        if (hp < 1)
        {
            nav.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Z_FallingBack");
            foreach (Collider col in GetComponents<Collider>())
            {
                col.enabled = false;
            }
            Destroy(gameObject, 5f);
        }

        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > radius)
        {
            nav.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Z_Idle");
        }

        if (dist < radius & dist > 2.3f)
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("Z_Run");
        }

        if (dist < 2.3f)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Z_Attack");
            nav.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rocket")
        {
            hp = hp - 100;
        }
    }
}
