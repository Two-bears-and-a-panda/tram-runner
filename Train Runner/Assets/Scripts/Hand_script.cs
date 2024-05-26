using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_script : MonoBehaviour
{
    private static float speed = 3f;
    private Renderer visual;


    void Start()
    {
        visual = GetComponent<Renderer>();
        visual.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.RyanMove)
        {
            visual.enabled = true;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            string objectName = gameObject.name;

            if (objectName == "Hand1")
            {
                mousePosition.y -= 1f;
                mousePosition.x -= 0.8f;
            }
            else
            {
                mousePosition.y -= 1f;
                mousePosition.x += 0.8f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < 100; i++)
                    transform.Rotate(0, 0, -900 * Time.deltaTime, Space.Self);
            }
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
        }
    }
}
