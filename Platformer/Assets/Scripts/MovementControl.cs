using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float spinTerminalMultiplier;
    public float Acceleration;
    public float MaxRun;
    float MoveJuice;
    public bool Spinning;
    void Start()
    {
        Spinning = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Spinning = !Spinning;
        }
    }
    void FixedUpdate()
    {
        MoveJuice = Input.GetAxis("Move");
        if (MoveJuice != 0)
        {
            Speedup();
            TerminalRun();
        }
        else
        {
            Slowdown();
        }
    }
    void Speedup() // Speeds up the character according to user input
    {
        rb.AddForce(Vector3.right * MoveJuice * Acceleration, ForceMode2D.Force);
    }
    void TerminalRun() // Slows down the character to "MaxRun" if they pass its value, limiting the character's horizontal movement to that speed cap in either direction
    {
        if (!Spinning && (rb.velocity.x > MaxRun))
        {
            rb.velocity = new Vector2(MaxRun, rb.velocity.y);
        }
        else if (!Spinning && (rb.velocity.x < -MaxRun))
        {
            rb.velocity = new Vector2(-MaxRun, rb.velocity.y);
        }
        else if (Spinning && (rb.velocity.x > (MaxRun * spinTerminalMultiplier)))
        {
            rb.velocity = new Vector2((MaxRun * spinTerminalMultiplier), rb.velocity.y);
        }
        else if (Spinning && (rb.velocity.x < (-MaxRun * spinTerminalMultiplier)))
        {
            rb.velocity = new Vector2((-MaxRun * spinTerminalMultiplier), rb.velocity.y);
        }

    }
    void Slowdown() // Slowly brings the character to a standing position while movement is not being inputted
    {
        if (rb.velocity.x > 0 | rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        }
        if ((rb.velocity.x > 0 && rb.velocity.x < 0.01)| (rb.velocity.x < 0 && rb.velocity.x > -0.01))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }
    
}
