using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 3f;

    public float Speed = 7;

    public string axis = "Vertical";

    public GameObject Fireball_Player;
    public GameObject Fireball_Enemy;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public float HP_Player = 1f;

    [SerializeField]
    private Image UIHP;

    [SerializeField]
    private Animator animator;

    public GameObject Death;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (HP_Player <= 0)
        {
            animator.enabled = true;
            Destroy(gameObject, .5f);
        }

        UIHP.fillAmount = HP_Player;

        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

        if (timeBtwShots <= 0) {
            if (Input.GetMouseButton(0))
            {
                Instantiate(Fireball_Player, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        float w = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(w, v) * Speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet_Enemy")
        {
            HP_Player = HP_Player - 0.2f;
            if (HP_Player <= 0)
            {
                Death.SetActive(true);
            }
        }
    }
}
