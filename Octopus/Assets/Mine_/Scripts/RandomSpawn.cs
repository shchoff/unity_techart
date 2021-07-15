using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    private float RandomY;
    private float RandomSpawnTime;
    Vector2 whereToSpawn;
    float nextSpawn = 0.0f;
    private float speed = 3f;

    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

        if (Time.time > nextSpawn)
        {
            RandomSpawnTime = Random.Range(2.5f, 4f);
            nextSpawn = Time.time + RandomSpawnTime;
            RandomY = Random.Range(-3.94f, 4.03f);
            whereToSpawn = new Vector2(transform.position.x, RandomY);
            Instantiate(Enemy, whereToSpawn, Quaternion.Euler(0f, 0f, -90f));
        }
    }
}
