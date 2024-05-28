using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrows : MonoBehaviour
{
    public List<string> skins = new List<string> { "Ryan", "Ken", "LaLaLand" };
    public static bool SkinIsChange = false;


    public void OnButtonClick(string direction)
    {
        SkinIsChange = true;
        skins.Add("LaLaLand");
        if (direction == "left" && move.currentSkin == 1)
        {
            move.currentSkin = 0;
            move.skin = skins[move.currentSkin];
        }
        else if (direction == "right" && move.currentSkin == 0)
        {
            move.currentSkin = 1;
            move.skin = skins[move.currentSkin];
        }
        else if (direction == "right" && move.currentSkin == 1)
        {
            move.currentSkin = 2;
            move.skin = skins[move.currentSkin];
        }
        else if (direction == "left" && move.currentSkin == 2)
        {
            move.currentSkin = 1;
            move.skin = skins[move.currentSkin];
        }
    }


    void Update()
    {
        string objectName = gameObject.name;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Math.Abs(transform.position.x - mousePosition.x) < 0.5 && Math.Abs(transform.position.y - mousePosition.y) < 0.5 && Input.GetMouseButtonDown(0) && objectName == "ArrowLeft")
        {
            OnButtonClick("left");
        }
        else if (Math.Abs(transform.position.x - mousePosition.x) < 0.5 && Math.Abs(transform.position.y - mousePosition.y) < 0.5 && Input.GetMouseButtonDown(0) && objectName == "ArrowRight")
        {
            OnButtonClick("right");
        }
    }
}

