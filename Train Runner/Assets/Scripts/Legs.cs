using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.InputManagerEntry;

public class Leg_script : MonoBehaviour
{
    private static float speed = 3f;
    private Renderer visual;
    private int tact = 0;
    private GameObject ryan;


    void Start()
    {
        visual = GetComponent<Renderer>();
        visual.enabled = false;
        ryan = GameObject.Find("Ryan");
    }

    IEnumerator ExampleCoroutine(int seconds)
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

            tact+=4;
            Vector2 mousePosition = ryan.transform.position;
            string objectName = gameObject.name;

            mousePosition.y -= 1.6f;
            if (objectName == "Leg1")
            {
                mousePosition.x -= 0.5f;
            }
            else
            {
                mousePosition.x += 0.5f;
            }

            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
            if (objectName == "Leg1")
            {
                if (transform.position.x > mousePosition.x)
                {
                    if (tact % 4 == 0)
                        transform.Rotate(0, 0, 500 * Time.deltaTime, Space.Self);
                }
                else if (transform.position.x < mousePosition.x)
                {
                    if (tact % 4 == 0)
                        transform.Rotate(0, 0, -500 * Time.deltaTime, Space.Self);
                }
            }
            else
            {
                if (transform.position.x > mousePosition.x)
                {
                    if (tact == 12)
                    {
                        ExampleCoroutine(4);
                    }
                    if (tact % 12 == 0)
                        transform.Rotate(0, 0, 900 * Time.deltaTime, Space.Self);
                }
                else if (transform.position.x < mousePosition.x)
                {
                    if (tact == 12)
                    {
                        ExampleCoroutine(4);
                    }
                    if (tact % 12 == 0)
                        transform.Rotate(0, 0, -900 * Time.deltaTime, Space.Self);
                }
            }

        }
    }
}
