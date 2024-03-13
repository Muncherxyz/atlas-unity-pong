using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{

    public float ballSpeed;
    public Rigidbody2D rb;
    public Vector2 direction;

    public TMP_Text LeftScore;
    public TMP_Text RightScore;

    public AudioSource audioPlayer;
    public AudioSource goalPlayer;
    
    public AudioSource bonkSound;

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
            bonkSound.Play();
            rb.velocity *= -1;
        }
        if(Collision.gameObject.CompareTag("Goal"))
        {
            if(transform.localPosition.x > 0)
            {
                ResetBall();
                goalPlayer.Play();
                LeftScore.text = (int.Parse(LeftScore.text) + 1).ToString();
            }
            else if(transform.localPosition.x < 0)
            {
                ResetBall();
                goalPlayer.Play();
                RightScore.text = (int.Parse(RightScore.text) + 1).ToString();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        if(Collision.gameObject.tag == "Wall")
        {
            audioPlayer.Play();
        }
    }

}
