using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Rendering;

public class CakeScript : MonoBehaviour
{
    private GameObject hand1;
    private GameObject hand2;
    public static bool TakeIt = false;
    private bool Punch = false;
    private int angle;
    private string hand = "";
    public static float power;
    private bool WasPushed = false;
    private int ShootLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        hand1 = GameObject.Find("Hand1");
        hand2 = GameObject.Find("Hand2");
    }

    void UpdatePowerCapsule()
    {
        var capsule = GameObject.Find("Capsule");
        capsule.transform.localScale = new Vector3(power, 0.1f, 0);
        var ryan = GameObject.Find("Ryan").transform.position;
        capsule.transform.localPosition = new Vector3(ryan.x, ryan.y + 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if ((Math.Abs(transform.position.x - hand1.transform.position.x) < 0.5f && Math.Abs(transform.position.y - hand1.transform.position.y) < 0.5f) ||
            (Math.Abs(transform.position.x - hand2.transform.position.x) < 0.5f && Math.Abs(transform.position.y - hand2.transform.position.y) < 0.5f))
        {
            if (!GameManager.TakeSomething && ShootLength == 0)
                TakeIt = true;
        }

        if (transform.position.x > mousePosition.x && TakeIt && !Punch)
        {
            transform.position = new Vector3(hand1.transform.position.x + 2, hand1.transform.position.y, 0);
            hand = "left";
        }
        else if (transform.position.x < mousePosition.x && TakeIt && !Punch)
        {
            transform.position = new Vector3(hand2.transform.position.x - 2, hand2.transform.position.y, 0);
            hand = "right";
        }


        if (Input.GetKey(KeyCode.Space) && TakeIt)
        {
            power += 0.01f;
            power = power < 2 ? power : 2;
            WasPushed = true;
        }
        else
        {   
            if (WasPushed)
            {
                WasPushed = false;
                TakeIt = false;
                ShootLength = (int)(10 * power);
            }
            power = 0;
        }

        UpdatePowerCapsule();

        if (ShootLength > 0)
        {
            if (move.moveDirection == "left")
                transform.position += new Vector3 (-Math.Abs(mousePosition.normalized.x / 2), mousePosition.normalized.y / 2, 0);
            if (move.moveDirection == "right")
                transform.position += new Vector3(Math.Abs(mousePosition.normalized.x / 2), mousePosition.normalized.y / 2, 0);
            ShootLength--;
        }

        if (Punch)
        {
            if (hand == "left")
            {
                transform.Rotate(0, 0, 3, Space.Self);
            }
            else
            {
                transform.Rotate(0, 0, -3, Space.Self);
            }
            angle += 3;
            if (angle == 360)
            {
                Punch = false;
                if (hand == "left")
                {
                    transform.position = new Vector3(hand1.transform.position.x + 2, hand1.transform.position.y, 0);
                }
                else if (hand == "right")
                {
                    transform.position = new Vector3(hand2.transform.position.x - 2, hand2.transform.position.y, 0);
                }
                angle = 0;
            }
        }

    }
}
