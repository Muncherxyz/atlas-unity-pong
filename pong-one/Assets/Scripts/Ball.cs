using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float ballSpeed;
    public Rigidbody2D rb;
    public Vector2 direction;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    
        Invoke("StartBall", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartBall()
    {
        rb.velocity = new Vector2(Random.insideUnitCircle.x, Random.insideUnitCircle.y).normalized * ballSpeed;
    }

    private void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.localPosition = new Vector2(0, 0);
        Invoke("StartBall", 2f);
    }
    

    void OnTriggerEnter2D(Collider2D Collision) 
    {
        if(Collision.gameObject.CompareTag("Paddle"))
        {
            rb.velocity *= -1;
        }
        if(Collision.gameObject.CompareTag("Goal"))
        {
            ResetBall();
        }
    }
}
