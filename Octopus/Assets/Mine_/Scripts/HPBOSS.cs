using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBOSS : MonoBehaviour
{
    public float hp = 1f;

    [SerializeField]
    private Image UIHP_Boss;

    void Update()
    {
        UIHP_Boss.fillAmount = hp;
    }

    public void GetHP(float hpB)
    {
        hp = hpB;
    }
}
