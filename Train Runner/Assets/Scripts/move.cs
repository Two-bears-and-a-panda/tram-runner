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
    public static string moveDirection = "";


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
                animator.SetFloat("SkinType", 1.5f);
            }
            else if (skin == "Ryan")
            {
                animator.SetFloat("SkinType", 0.5f);
            }
            else
            {
                animator.SetFloat("SkinType", 2.5f);
            }
        }
        if (GameManager.RyanMove)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);

            if (transform.position.x > mousePosition.x)
            {
                moveDirection = "left";
                transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (transform.position.x < mousePosition.x)
            {
                moveDirection = "right";
                transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
