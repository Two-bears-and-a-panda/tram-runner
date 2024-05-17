using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_script : MonoBehaviour
{
    private static float speed = 3f;
    private static bool flag = false;
    private Renderer visual;
    // Start is called before the first frame update
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
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
        }
    }
}
