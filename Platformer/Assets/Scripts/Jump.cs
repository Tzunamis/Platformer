using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Jump : MonoBehaviour {



    [SerializeField] KeyCode jumpKey = KeyCode.UpArrow;
    //KeyCode jumpButton = KeyCode.Space;
    [SerializeField] float jumpForce = 1;
    [SerializeField] float MultiJumpForce = 1;

    Rigidbody2D rb;

    [SerializeField] float Gravitas = 1.0f;
    [SerializeField] float GravitiPlunge = 1.0f;
    [SerializeField] float GravityCancel = 1.0f;

    [SerializeField] bool onGround = true;
    int nbMultiJump = 0;
    int nbMultiJumpLeft;
    bool isJumping;


    public bool IsJumping() 
    {
        return isJumping;
    }
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() 
    {
        isJumping = false;
    }

    void ManageJump() {
        if (!rb)
            return;

        if (onGround && Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;
            nbMultiJumpLeft = nbMultiJump;
        }

        else if (nbMultiJumpLeft > 0 && Input.GetKeyDown(jumpKey))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(Vector2.up * MultiJumpForce, ForceMode2D.Impulse);
            nbMultiJumpLeft--;
        }

    }

    void ManageGravity() 
    {
        if (!rb)
            return;



        if (rb.velocity.y > 0)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                rb.gravityScale = Gravitas;
            }
            else
                rb.gravityScale = GravityCancel;
        }



        else 
        {
            rb.gravityScale = GravitiPlunge;
        }
    }



    // Update is called once per frame
    void Update() {
        ManageJump();
        ManageGravity();



    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Ground")
        {
            isJumping = false;
            onGround = true;
        }
    }
}