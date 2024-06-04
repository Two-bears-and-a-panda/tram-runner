using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train2 : MonoBehaviour
{
    private const float trainLength = Train.trainLength;
    private Renderer visual;
    private GameObject ryan;


    IEnumerator ExampleCoroutine(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        visual.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        ExampleCoroutine(2);
        visual = GetComponent<Renderer>();
        ryan = GameObject.Find("Ryan");

    }

    void Update()
    {
        if (visual.enabled && Train.arrived)
        {
            var position = GameObject.Find("Train").transform.position;
            position.x = ((int)(ryan.transform.position.x / trainLength) - 1) * trainLength;
            transform.position = position;
        }
    }
}