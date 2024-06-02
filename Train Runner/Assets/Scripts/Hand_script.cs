using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hand_script : MonoBehaviour
{
    private static float speed = 3f;
    private Renderer visual;
    private GameObject ryan;
    private bool left = false;
    private bool right = false;
    private int angleLeft = 0;
    private int angleRight = 0;


    void Start()
    {
        visual = GetComponent<Renderer>();
        ryan = GameObject.Find("Ryan");
        visual.enabled = false;
    }

    IEnumerator ExampleCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        visual.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.RyanMove)
        {
            visual.enabled = true;
            Vector2 mousePosition = ryan.transform.position;
            string objectName = gameObject.name;

            if (objectName == "Hand1")
            {
                mousePosition.y -= 1f;
                mousePosition.x -= 1.3f;
            }
            else
            {
                mousePosition.y -= 1f;
                mousePosition.x += 1.3f;
            }
            if (Input.GetKeyDown(KeyCode.Space) && !GameManager.TakeSomething)
            {
                if (move.moveDirection == "left" && objectName == "Hand1")
                {
                    left = true;
                    right = false;
                }
                else if (move.moveDirection == "right" && objectName == "Hand2")
                {
                    right = true;
                    left = false;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);


            if (left && objectName == "Hand1")
            {
                transform.Rotate(0, 3, 0, Space.Self);
                angleLeft += 3;
                if (angleLeft == 360)
                {
                    left = false;
                    angleLeft = 0;
                }
            }
            else if (right && objectName == "Hand2")
            {
                transform.Rotate(0, 3, 0, Space.Self);
                angleRight += 3;
                if (angleRight == 360)
                {
                    right = false;
                    angleRight = 0;
                }
            }
        }
    }
}
