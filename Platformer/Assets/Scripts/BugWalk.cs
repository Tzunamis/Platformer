using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugWalk : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float WalkSpeed;
    bool WalkRight;
    float CurrentSpeed;
    public float MaxRight;
    public float MaxLeft;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        CurrentSpeed = rb.velocity.magnitude;

        if (WalkRight)
        {
            rb.velocity = new Vector2(WalkSpeed, 0);
            sr.flipX = true;
            if (/*CurrentSpeed == 0 |*/ rb.position.x > MaxRight)
            {
                WalkRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-WalkSpeed, 0);
            sr.flipX = false;
            if (/*CurrentSpeed == 0 |*/ rb.position.x < MaxLeft)
            {
                WalkRight = true;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        WalkRight = !WalkRight;
    }
}
