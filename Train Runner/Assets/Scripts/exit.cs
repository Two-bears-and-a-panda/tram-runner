using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    private static float speed = 0.04f;
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
        yield return new WaitForSeconds(3000);

        visual.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (visual.enabled)
        {
            if (transform.position.x < -2.4)
            {
                transform.position += new Vector3(speed, 0, 0);
            }
        }
    }
}