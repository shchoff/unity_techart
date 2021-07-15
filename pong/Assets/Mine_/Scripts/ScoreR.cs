using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreR : MonoBehaviour
{
    public int scorer = 0;
    public Text scoreDisplayR;
    private Ball bll;
    public GameObject PanelB;

    void Start()
    {
        bll = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        scoreDisplayR.text = scorer.ToString();
    }

    public void PointR()
    {
        scorer++;
        bll.RandomPosR();
        if (scorer == 7)
        {
            Time.timeScale = 0;
            PanelB.SetActive(true);
        }
    }
}
