using UnityEngine;
using System.Collections;

public class MoveToGosling : MonoBehaviour
{
    public float DisplacementCoef = 0.5f;
    public GameObject target;
    public float MaxSpeed = 1;
    public float stopDistance = 1;
    public GameObject GameOver;


    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        GameOver.SetActive(false);
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

        if (Vector3.Distance(transform.position, target.transform.position) < stopDistance)
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        var coords = Camera.main.transform.position;
        coords.z = 0;
        GameOver.transform.position = coords;
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
