using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float TerminalVelocity;
    public float SpinJumpMultiplier;
    float JumpJuice;
    public bool CanJump;
    public float JumpPower;
    bool Spinning;
    int JumpCheckCounter;
    MovementControl MC;
    void Start()
    {
        MC = GetComponent<MovementControl>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Spinning = MC.Spinning;
        JumpCheck();
        JumpJuice = Input.GetAxisRaw("Vertical");
        if (JumpJuice == 1 && CanJump)
        {
            Jumpup();
        }
        TerminalFall();
    }
    void TerminalFall() // Slows the player's fall if its value passes TerminalVelocity
    {
        if (rb.velocity.y < -TerminalVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, -TerminalVelocity);
        }
    }
    void Jumpup() // If inputting for a jump, the character will be launched up based on "Spinning"
    {
        if (Spinning)
        {
            rb.AddForce(Vector2.up * JumpPower * SpinJumpMultiplier, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }
    void JumpCheck() // Counts how long the player is not moving on the y-axis. If they are static for 5 frames, it is assumed they are grounded and so their jump is replenished.
    {
        if (rb.velocity.y == 0 && !CanJump)
        {
            {
                JumpCheckCounter++;
                if (JumpCheckCounter >= 5)
                {
                    CanJump = true;
                    JumpCheckCounter = 0;
                }
            }
        }
        else if (rb.velocity.y != 0)
        {
            CanJump = false;
        }
        else
        {
            JumpCheckCounter = 0;
        }
    }

   

}
