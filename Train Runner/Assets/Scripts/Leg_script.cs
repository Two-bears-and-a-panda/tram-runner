using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Leg_script : MonoBehaviour
{
    private static float speed = 3f;
    private static bool flag = false;
    private Renderer visual;

    // Start is called before the first frame update
    void Start()
    {
        visual = GetComponent<Renderer>();
        visual.enabled = !visual.enabled;
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        flag = true;
        visual.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            string objectName = gameObject.name;

            if (objectName == "Leg1")
            {
                mousePosition.y -= 1.6f;
                mousePosition.x -= 0.5f;
            }
            else
            {
                mousePosition.y -= 1.6f;
                mousePosition.x += 0.5f;
            }

            

            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
        }
    }
}
