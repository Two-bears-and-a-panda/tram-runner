using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class move : MonoBehaviour
{
    private static float speed = 3f;
    private static bool flag = false;
    private float scaleAmount = 0.4f;
    private float scaleSpeed = 1.5f;
    private Renderer visual;
    // Start is called before the first frame update
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
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

    // Update is called once per frame :)
    void Update()
    {
        if (flag)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
            if (transform.position.x > mousePosition.x)
            {
                transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
            }
            else if (transform.position.x < mousePosition.x)
            {
                transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
            }


            // Получаем текущий масштаб по оси Y
            float currentScaleY = transform.localScale.y;

            // Рассчитываем целевой масштаб по оси Y
            float targetScaleY = currentScaleY + Mathf.PingPong(Time.time * scaleSpeed, scaleAmount) - scaleAmount / 2;

            // Плавно изменяем масштаб по оси Y к целевому значению
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(currentScaleY, targetScaleY, Time.deltaTime * scaleSpeed), transform.localScale.z);
        }
    }
}
