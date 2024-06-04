using UnityEngine;

public class NPCScript : MonoBehaviour
{
    private Renderer visual;

    private Rigidbody2D rb2d;

    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float minTime = 1.5f;
    public float maxTime = 3f;

    private float nextMovementTime;
    private Vector2 movementDirection;

    void Start()
    {
        visual = GetComponent<Renderer>();

        rb2d = GetComponent<Rigidbody2D>();

        nextMovementTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    void Update()
    {
        if (!visual.enabled || Time.time < nextMovementTime)
            return;

        movementDirection = UnityEngine.Random.insideUnitCircle.normalized;
        var movementDelay = UnityEngine.Random.Range(minTime, maxTime);
        nextMovementTime = Time.time + movementDelay;
        rb2d.velocity = movementDirection * Random.Range(minSpeed, maxSpeed);
    }
}