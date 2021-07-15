using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMoving : MonoBehaviour
{
    private float speed = 2.8f;
    private float HPBoss = 1f;

    [SerializeField]
    private Animator animator;

    public Transform shotPoint;
    public Transform shotPoint1;
    public Transform shotPoint2;
    public Transform shotPoint3;
    public Transform shotPoint4;
    public Transform shotPoint5;
    public Transform shotPoint6;
    private float timeBtwShots;
    private float timeBtwShots1;
    public float startTimeBtwShots;

    public GameObject Fireball_Enemy;
    public GameObject Fireball_Player;

    private Panel pl;

    private Game_Controller end;

    private HPBOSS hpb;

    void Start()
    {
        end = FindObjectOfType<Game_Controller>();
        pl = FindObjectOfType<Panel>();
        hpb = FindObjectOfType<HPBOSS>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

        if (HPBoss <= 0)
        {
            animator.enabled = true;
            Destroy(gameObject, .5f);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(Fireball_Enemy, shotPoint1.position, Quaternion.Euler(0f, 0f, -100f));
            Instantiate(Fireball_Enemy, shotPoint2.position, Quaternion.Euler(0f, 0f, -100f));
            Instantiate(Fireball_Enemy, shotPoint3.position, transform.rotation);
            Instantiate(Fireball_Enemy, shotPoint4.position, Quaternion.Euler(0f, 0f, -80f));
            Instantiate(Fireball_Enemy, shotPoint5.position, Quaternion.Euler(0f, 0f, -80f));
            Instantiate(Fireball_Enemy, shotPoint6.position, transform.rotation);

            timeBtwShots = startTimeBtwShots;
            if (timeBtwShots1 <= 0)
            {
                Instantiate(Fireball_Enemy, shotPoint.position, transform.rotation);
                timeBtwShots1 = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
            timeBtwShots1 -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            HPBoss = HPBoss - 0.05f;
            pl.PointR();
            hpb.GetHP(HPBoss);
            if (HPBoss <= 0)
            {
                end.TheEndOFTheGame();
            }
        }
    }
}
