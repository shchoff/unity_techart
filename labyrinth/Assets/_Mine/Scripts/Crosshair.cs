using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D pricel;

    public void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2 - 30, Screen.height / 2, 40, 40), pricel);
    }
}
