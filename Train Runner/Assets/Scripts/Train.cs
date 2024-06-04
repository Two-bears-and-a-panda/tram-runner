using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

public class Train : MonoBehaviour
{
    public const float trainLength = 29.162f;
    private static float speed = 0.04f;
    public Sprite NewSprite;
    public Sprite DoorsSprite;
    private Renderer visual;
    public static bool arrived;
    private GameObject ryan;
    public static bool IsGrassMove = false;
    public static bool TimeToOpen = false;
    public static bool IsOpen = false;

    public static int Counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        visual = GetComponent<Renderer>();
        visual.enabled = false;
        ryan = GameObject.Find("Ryan");
    }

    IEnumerator ExampleCoroutine2(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.Stoping = false;
        IsGrassMove = true;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = NewSprite;
    }

    void StartGrassMove()
    {
        var grass = GameObject.Find("Grass");
        if  (grass.transform.position.x + 40 < GameObject.Find("Ryan").transform.position.x)
        {
            grass.transform.position = new Vector3(grass.transform.position.x + 70, grass.transform.position.y, 0);
        }
        else
        {
            grass.transform.position = new Vector3(grass.transform.position.x - 0.2f, grass.transform.position.y, 0);
        }
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
                var head = GameObject.Find("TrainHead");
                head.transform.position = new Vector3(transform.position.x + 19, transform.position.y, 0);
                head.GetComponent<Renderer>().enabled = true;
                IsGrassMove = true;
            }

            if (IsGrassMove)
            {
                StartGrassMove();
            }

            if (arrived)
            {
                var position = transform.position;
                position.x = (int)(ryan.transform.position.x / trainLength) * trainLength;
                transform.position = position;
            }

            if (GameManager.Stoping)
            {
                IsGrassMove = false;
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                renderer.sprite = DoorsSprite;
                GameManager.Stoping = false;
                var doorLeft = GameObject.Find("DoorLeft");
                var doorRight = GameObject.Find("DoorRight");
                doorLeft.transform.localScale = new Vector3(0.5782f, 0.3387489f, 0);
                doorRight.transform.localScale = new Vector3(0.5782f, 0.3387489f, 0);
                doorLeft.GetComponent<Renderer>().enabled = true;
                doorRight.GetComponent<Renderer>().enabled = true;
                TimeToOpen = true;
            }

            if (TimeToOpen)
            {
                var doorLeft = GameObject.Find("DoorLeft");
                var doorRight = GameObject.Find("DoorRight");
                doorLeft.transform.position = new Vector3(transform.position.x - 5, transform.position.y - 5, 0);
                doorRight.transform.position = new Vector3(transform.position.x + 5, transform.position.y - 5, 0);
                if (doorLeft.transform.localScale.x <= 0)
                {
                    IsOpen = true;
                    TimeToOpen = false;
                }
                else
                {
                    doorLeft.transform.localScale = new Vector3(doorLeft.transform.localScale.x - 0.0007f, 0.3387489f, 0);
                    doorRight.transform.localScale = new Vector3(doorRight.transform.localScale.x - 0.0007f, 0.3387489f, 0);
                }
            }

            if (IsOpen)
            {
                GameObject.Find("DoorLeft").GetComponent<Renderer>().enabled = false;
                GameObject.Find("DoorRight").GetComponent<Renderer>().enabled = false;
                var doorRight = GameObject.Find("DoorRight");
                IsOpen = false;
                Debug.Log("is open");
                StartCoroutine(ExampleCoroutine2(5));
            }
        }
    }
}