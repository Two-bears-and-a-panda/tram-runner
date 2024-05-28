using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class batScript : MonoBehaviour
{
    private GameObject hand1;
    private GameObject hand2;
    public static bool TakeIt = false;
    private bool Punch = false;
    private int angle;
    private string hand = "";

    // Start is called before the first frame update
    void Start()
    {
        hand1 = GameObject.Find("Hand1");
        hand2 = GameObject.Find("Hand2");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if ((Math.Abs(transform.position.x - hand1.transform.position.x) < 0.5f && Math.Abs(transform.position.y - hand1.transform.position.y) < 0.5f) ||
            (Math.Abs(transform.position.x - hand2.transform.position.x) < 0.5f && Math.Abs(transform.position.y - hand2.transform.position.y) < 0.5f))
        {
            if (!GameManager.TakeSomething)
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


        if (Input.GetKeyDown(KeyCode.Space) && TakeIt)
        {
            Punch = true;
            if (hand == "left")
            {
                transform.position = new Vector3(hand2.transform.position.x - 2, hand2.transform.position.y, 0);
            }
            else if (hand == "right")
            {
                transform.position = new Vector3(hand1.transform.position.x + 2, hand1.transform.position.y, 0);
            }
        }

        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && TakeIt)
        {
            TakeIt = false;
            transform.position += new Vector3(mousePosition.normalized.x * 2, mousePosition.normalized.y * 2, 0);
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
