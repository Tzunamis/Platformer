using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    Rigidbody2D rb;

    public Animator anim;
    public float TerminalRun;
    public float spinTerminalMultiplier;
    public float Acceleration;
    public float SpinAccelMultiplier;
    public float AirAccelMultiplier;
    float MoveJuice;
    public bool Spinning;
    float MovePower;
    public bool isMoving;
    JumpControl JC;
    ButtonPress BP;
    SpriteRenderer SR;
    void Start()
    {
        Spinning = false;
        anim = GetComponent<Animator>();

        SR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        JC = GetComponent<JumpControl>();
        BP = GameObject.Find("LAUNCH NUKE!").GetComponent<ButtonPress>();
    }

    void Update()
    {

        

        if(rb.velocity.x != 0 && JC.CanJump == true)
        {
            isMoving = true;
            anim.SetBool("isMoving", true);
        }
        else
        {
            isMoving = false;
            anim.SetBool("isMoving", false);
        }
        if(rb.velocity.x > 0)
        {
            SR.flipX = false;
        }
        
        if (rb.velocity.x < 0)
        {
            SR.flipX = true;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && BP.InputEnabled)
        {
            Spinning = !Spinning;
            anim.SetBool("Spinning", Spinning);
        }
        
    }
    void FixedUpdate()
    {
        MoveJuice = Input.GetAxis("Move");
        if (MoveJuice != 0 && BP.InputEnabled)
        {
            Speedup();
            SlowToMax();
        }
        else
        {
            Slowdown();
        }
    }
    void Speedup() // Speeds up the character according to user input
    {
        MovePower = MoveJuice * Acceleration;
        if (Spinning)
        {
            MovePower *= SpinAccelMultiplier;
        }
        if (!JC.CanJump)
        {
            MovePower *= AirAccelMultiplier;
        }
        rb.AddForce(Vector3.right * MovePower, ForceMode2D.Force);
    }
    void SlowToMax() // Slows down the character to "MaxRun" if they pass its value, limiting the character's horizontal movement to that speed cap in either direction
    {
        if (!Spinning && (rb.velocity.x > TerminalRun))
        {
            rb.velocity = new Vector2(TerminalRun, rb.velocity.y);
        }
        else if (!Spinning && (rb.velocity.x < -TerminalRun))
        {
            rb.velocity = new Vector2(-TerminalRun, rb.velocity.y);
        }
        else if (Spinning && (rb.velocity.x > (TerminalRun * spinTerminalMultiplier)))
        {
            rb.velocity = new Vector2((TerminalRun * spinTerminalMultiplier), rb.velocity.y);
        }
        else if (Spinning && (rb.velocity.x < (-TerminalRun * spinTerminalMultiplier)))
        {
            rb.velocity = new Vector2((-TerminalRun * spinTerminalMultiplier), rb.velocity.y);
        }

    }
    void Slowdown() // Slowly brings the character to a standing position while movement is not being inputted
    {
        if (rb.velocity.x != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        }
        if ((rb.velocity.x > 0 && rb.velocity.x < 0.01)| (rb.velocity.x < 0 && rb.velocity.x > -0.01))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }
    
}
