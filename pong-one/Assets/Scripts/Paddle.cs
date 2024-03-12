using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private RectTransform rbTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
