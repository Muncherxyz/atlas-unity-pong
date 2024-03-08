using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public KeyCode upKey;
    public KeyCode downKey;

    float moveSpeed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerBounds();
    }

    void playerMovement()
    {
        if(Input.GetKey(upKey))
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }
        if(Input.GetKey(downKey))
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
    }

    void playerBounds()
    {
        if(transform.position.y >= 960)
        {
            transform.position = new Vector2(transform.position.x, 960);
        }
        else if(transform.position.y <= 120f)
        {
            transform.position = new Vector2(transform.position.x, 120f);
        }
    }
}
