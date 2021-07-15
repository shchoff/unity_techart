using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2f;
    public float HP_Enemy;

    [SerializeField]
    private Animator animator;

    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject Fireball_Enemy;
    public GameObject Fireball_Player;

    public int score;

    private Panel pl;


    void Start()
    {
        animator = GetComponent<Animator>();
        pl = FindObjectOfType<Panel>();
        HP_Enemy = Random.Range(1f, 3f);
    }

    private void Update()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;

        if (timeBtwShots <= 0)
        {
                Instantiate(Fireball_Enemy, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (HP_Enemy <= 0)
        {
            animator.enabled = true;
            Destroy(gameObject, .5f);
            
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            HP_Enemy = HP_Enemy - 1;
            if (HP_Enemy <= 0)
            {
                pl.PointR();
            }
        }
    }
}
