using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 3f;
    public float horizontalBound = 32f;
    private Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerBoundary();
    }

    void PlayerBoundary()
    {
        if (transform.position.x < -horizontalBound)
        {
            transform.position = new Vector2(-horizontalBound, transform.position.y);
        }
        else if (transform.position.x > horizontalBound)
        {
            transform.position = new Vector2(horizontalBound, transform.position.y);
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }
    }
    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }
    }
    public void ModifySpeed(float speedModifier)
    {
        speed *= speedModifier;
    }
}
