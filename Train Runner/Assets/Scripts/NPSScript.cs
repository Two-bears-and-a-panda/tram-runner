using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.Rendering;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class NPSScript : MonoBehaviour
{
    private Renderer visual;

    private Rigidbody2D rb2d;

    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float minTime = 1.5f;
    public float maxTime = 3f;

    private float nextMovementTime;
    private float movementDuration;
    private Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        visual = GetComponent<Renderer>();
        visual.enabled = false;

        rb2d = GetComponent<Rigidbody2D>();

        // Set the next movement time to a random value between minTime and maxTime
        nextMovementTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    public static void ShowYourself(float x, float y, GameObject obj)
    {
        obj.transform.position = new Vector3(x, y, 0);
        var visual = obj.GetComponent<Renderer>();
        visual.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (visual.enabled)
        {
            // Check if it is time to move
            if (Time.time >= nextMovementTime)
            {
                // Set the movement duration to a random value between minTime and maxTime
                movementDuration = UnityEngine.Random.Range(minTime, maxTime);

                // Choose a random movement direction
                movementDirection = UnityEngine.Random.insideUnitCircle.normalized;

                // Set the next movement time to the current time plus the movement duration
                nextMovementTime = Time.time + movementDuration;
            }

            // Move the NPC in the chosen direction with the chosen speed
            rb2d.velocity = movementDirection * UnityEngine.Random.Range(minSpeed, maxSpeed);
        }
    }
}
