using UnityEngine;

public class MoveToGosling : MonoBehaviour
{
    public float interpVelocity;
    public GameObject target;
    Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
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
