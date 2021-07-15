using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField]
    private GameObject RandomSpawner;
    public int scorer = 0;
    public Text scoreDisplayR;
    private BossSpawner bss;

    private void Update()
    {      
        bss = FindObjectOfType<BossSpawner>();
        scoreDisplayR.text = scorer.ToString();
    }

    public void PointR()
    {
        scorer++;
        if (scorer == 20)
        {
            RandomSpawner.SetActive(false);
            bss.BossComes();
        }
    }
}
