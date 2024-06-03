using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSeats : MonoBehaviour
{
    public float CursorOffset;
    public float SeatsStep;
    public GameObject Prefab;

    private Queue<GameObject> seats = new();
    private float nextSeatXCoord;

    void Start()
    {
        nextSeatXCoord = CursorOffset;
    }

    void Update()
    {
        if (GameManager.RyanMove)
        {
            var generationCursor = GameManager.ryan.transform.position.x + CursorOffset;
            var deletetionCursor = GameManager.ryan.transform.position.x - CursorOffset;

            if (generationCursor < nextSeatXCoord)
            {
                var seatPosition = new Vector3(nextSeatXCoord, Random.Range(GameManager.BottomBorder, GameManager.TopBorder));
                seats.Enqueue(Instantiate(Prefab, seatPosition, Quaternion.identity));

                nextSeatXCoord += SeatsStep;
            }

            if (seats.TryPeek(out var oldestSeat) && deletetionCursor < oldestSeat.transform.position.x)
            {
                Destroy(oldestSeat);
                seats.Dequeue();
            }

        }
    }
}
