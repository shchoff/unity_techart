using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject BOSS;

    [SerializeField]
    private GameObject HpPanel;

    private float speed = 3f;

    void Update()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    public void BossComes()
    {
        Instantiate(BOSS, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0f, 0f, -90f));
        HpPanel.SetActive(true);
    }
}
