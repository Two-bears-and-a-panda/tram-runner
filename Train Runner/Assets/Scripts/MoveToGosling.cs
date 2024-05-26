using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveToGosling : MonoBehaviour
{
    public float interpVelocity;
    public GameObject target;
    private Renderer visual;
    Vector3 targetPos;

    void Start()
    {
        visual = GetComponent<Renderer>();
        visual.enabled = !visual.enabled;
        StartCoroutine(ExampleCoroutine());
        targetPos = transform.position;
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3000);

        visual.enabled = true;
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 currentPositionNoZ = transform.position;
            currentPositionNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - currentPositionNoZ);

            interpVelocity = targetDirection.magnitude * 3f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos, 0.25f);

        }
    }
}
