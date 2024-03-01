using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float strtSpd = 10;
    [SerializeField] private float spdIncrease = 0.25f;
    private int hitCounter;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, strtSpd + spdIncrease);
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (strtSpd + spdIncrease);
    }
}
