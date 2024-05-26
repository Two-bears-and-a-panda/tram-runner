using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class move : MonoBehaviour
{
    private static float speed = 3f;
    private static bool IsTimeToShowSkin = false;
    private float scaleAmount = 0.3f;
    private float scaleSpeed = 1.3f;
    private Renderer visual;
    public Animator animator;
    public static string skin = "Ryan";
    public static int currentSkin = 0;


    void Start()
    {
        visual = GetComponent<Renderer>();
        visual.enabled = false;
        StartCoroutine(ExampleCoroutine(22));
    }

    IEnumerator ExampleCoroutine(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        visual.enabled = true;
        IsTimeToShowSkin = true;
    }

    void Update()
    {
        if (IsTimeToShowSkin)
        {
            if (skin == "Ken")
            {
                animator.SetFloat("SkinType", 100f);
            }
            else
            {
                animator.SetFloat("SkinType", -2f);
            }
        }
        if (GameManager.RyanMove)
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
        }
    }
}
