using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 120;
    private ScoreL sl;
    private ScoreR sr;

    private bool playGame = true;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        //StartCoroutine(CheckIfPlayersAreReady());
    }


    void Update()
    {
        sl = FindObjectOfType<ScoreL>();
        sr = FindObjectOfType<ScoreR>();

        if (playGame == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                playGame = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                playGame = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "racket_bl")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "racket_rd")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "GateL")
        {
            sl.Point();
        }
        if (col.gameObject.name == "GateR")
        {
            sr.PointR();
        }
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    public void RandomPosR()
    {
        transform.position = new Vector2(0, 0);
        float rand = Random.Range(-45, -10);
        float rand1 = Random.Range(-20, 20);
        Vector2 dir = new Vector2(rand, rand1).normalized;
        // StartCoroutine(CheckIfPlayersAreReady());
        GetComponent<Rigidbody2D>().velocity = (dir * speed) / 2;
    }

    public void RandomPosL()
    {
        transform.position = new Vector2(0, 0);
        float rand = Random.Range(10, 45);
        float rand1 = Random.Range(-20, 20);
        Vector2 dir = new Vector2(rand, rand1).normalized;
        //StartCoroutine(CheckIfPlayersAreReady());
        GetComponent<Rigidbody2D>().velocity = (dir * speed) / 2;
    }

        // IEnumerator CheckIfPlayersAreReady()
        // {
        //    Debug.Log("Waiting for the Exit button to be pressed");
        //     yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.Escape));
        //     Debug.Log("Exit button has been pressed. Leaving Application");
        // }
    }
