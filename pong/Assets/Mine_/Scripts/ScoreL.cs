using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreL : MonoBehaviour
{
    public int score = 0;
    public Text scoreDisplay;
    private Ball bll;
    public GameObject PanelR;

    void Start()
    {
        bll = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        scoreDisplay.text = score.ToString();
    }

    public void Point()
    {
        score++;
        bll.RandomPosL();
        if (score == 7)
        {
            Time.timeScale = 0;
            PanelR.SetActive(true);
        }
    }
}
