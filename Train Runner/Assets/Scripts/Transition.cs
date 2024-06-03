using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private Renderer visual;
    private static bool IsTimeToShow = false;
    public static bool IsTimeToHide = false;
    private float visability = 0f;


    void Start()
    {
        visual = GetComponent<Renderer>();
        visual.enabled = false;
        StartCoroutine(ExampleCoroutine(20));
    }

    IEnumerator ExampleCoroutine(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0, 0, 0, 0); //������ ������ ��� ����������
        visual.enabled = true;
        IsTimeToShow = true;
    }


    void Update()
    {
        if (IsTimeToShow)
        {            
            if (IsTimeToHide)
            {
                var spriteRebderer = GetComponent<SpriteRenderer>();
                spriteRebderer.color = new Color(0, 0, 0, visability);
                visability -= 0.0007f;
                if (visability <= 0f)
                {
                    IsTimeToShow = false;
                }
            }
            else
            {
                var spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(0, 0, 0, visability);
                visability += 0.002f;
                if (visability >= 1f)
                {
                    IsTimeToHide = true;
                    spriteRenderer.color = new Color(0, 0, 0, 1);
                }
            }
        }

        //���� ���� ������ Lets Go - ��� ����� ����� ����������
        if (StartButton.IsItLetsGo)
        {
            IsTimeToShow = true;
            IsTimeToHide = false;
            visability = 0f;
            StartButton.IsItLetsGo = false;
        }
    }
}
