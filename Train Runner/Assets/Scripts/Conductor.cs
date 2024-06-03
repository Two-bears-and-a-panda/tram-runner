using UnityEngine;
using System.Collections;

public class MoveToGosling : MonoBehaviour
{
    public float DisplacementCoef = 0.5f;
    public GameObject target;
    public float MaxSpeed = 1;

    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void FixedUpdate()
    {
        if (!target)
        {
            return;
        }

        var targetDirection = (target.transform.position - transform.position);
        targetDirection.z = 0;

        var displacement = targetDirection * DisplacementCoef * Time.deltaTime;
        displacement = displacement.normalized * Mathf.Clamp(displacement.magnitude, 0, MaxSpeed * Time.deltaTime);

        transform.position += displacement;
    }
}
