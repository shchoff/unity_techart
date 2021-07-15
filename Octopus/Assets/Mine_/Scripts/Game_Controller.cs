using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    private bool playGame = true;
    public GameObject Panel;
    public GameObject PanelScore;
    public GameObject PanelHP;
    public GameObject TheEndPanel;

    void Update()
    {
        if (playGame == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                playGame = false;
                PanelScore.SetActive(false);
                PanelHP.SetActive(false);
                Panel.SetActive(true);
;            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                playGame = true;
                PanelScore.SetActive(true);
                PanelHP.SetActive(true);
                Panel.SetActive(false);
            }
        }
    }

    public void TheEndOFTheGame()
    {
        PanelHP.SetActive(false);
        TheEndPanel.SetActive(true);
        Time.timeScale = 0;
    }

}
