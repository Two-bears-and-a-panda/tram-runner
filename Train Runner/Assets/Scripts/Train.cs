using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public const float trainLength = 29.162f;
    private static float speed = 0.04f;
    public Sprite NewSprite;
    private Renderer visual;
    public static bool arrived;
    private GameObject ryan;

    // Start is called before the first frame update
    void Start()
    {
        visual = GetComponent<Renderer>();
        visual.enabled = false;
        StartCoroutine(ExampleCoroutine());
        ryan = GameObject.Find("Ryan");


    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3000);

        visual.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (visual.enabled)
        {
            if (transform.position.x < 0.7)
            {
                transform.position += new Vector3(speed, 0, 0);
            }
            else if (!arrived)
            {
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                renderer.sprite = NewSprite;
                arrived = true;
            }

            if (arrived)
            {
                var position = transform.position;
                position.x = (int)(ryan.transform.position.x / trainLength) * trainLength;
                transform.position = position;
            }
        }
    }
}