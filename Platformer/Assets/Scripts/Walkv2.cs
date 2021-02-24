using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*public class Walkv2 : MonoBehaviour
 {


    public KeyCode inputRight = KeyCode.RightArrow;
    public KeyCode inputLeft = KeyCode.LeftArrow;

    
    [SerializeField] float topSpeed;
    [SerializeField] float slideEffectAccel;
    float currentSpeed;
    float slideEffectRatio = 0;
    public bool wantingToGoRight;
    public bool wantingToGoLeft;
    public bool isInSlideMode = false;
    public bool inFightingAgainstSlideMode = false;

    bool isInputLocked = false;

    public void SetInputLock(bool value) 
    {
        isInputLocked = value;
    }


    public float GetCurrentSpeed() { return currentSpeed; }
    void GetPlayerWantedDirectionWithKeyCode() 
    {
        if(isInputLocked)
        {
            wantingToGoLeft = false;
            wantingToGoRight = false;
            return;
        }

        if (Input.GetKey(inputRight))
        {
            wantingToGoRight = true;
            wantingToGoLeft = false;
        }
        else if (Input.GetKey(inputLeft))
        {
            wantingToGoRight = false;
            wantingToGoLeft = true;
        }

        if (wantingToGoRight && !Input.GetKey(inputRight))
        {
            wantingToGoRight = false;
            if (Input.GetKey(inputLeft))
                wantingToGoLeft = true;
        }
        if (wantingToGoLeft && !Input.GetKey(inputLeft))
        {
            wantingToGoLeft = false;
            if (Input.GetKey(inputRight))
                wantingToGoRight = true;
        }

    }
    void ManageTransformKeyCode(float deltaTime)
    {

        Vector3 desiredPos = transform.position;


        if (wantingToGoLeft && currentSpeed <= 0)
        {
            isInSlideMode = false;
            inFightingAgainstSlideMode = false;
            currentSpeed = -topSpeed;
            slideEffectRatio = 1;
        }
        else if (wantingToGoRight && currentSpeed >= 0)
        {
            isInSlideMode = false;
            inFightingAgainstSlideMode = false;
            currentSpeed = topSpeed;
            slideEffectRatio = 1;
        }
        else
        {
            isInSlideMode = true;
            slideEffectRatio -= slideEffectAccel;
            if (slideEffectRatio <= 0)
            {
                slideEffectRatio = 0;
                currentSpeed = 0;
                isInSlideMode = false;
            }

            if(isInSlideMode)
            {
                inFightingAgainstSlideMode = (currentSpeed < 0 && wantingToGoRight) || (currentSpeed > 0 && wantingToGoLeft);
            }
        }

        desiredPos += (Vector3.right * currentSpeed * slideEffectRatio * deltaTime);
        

        transform.position = desiredPos;

    }


    private void FixedUpdate() 
    {
        ManageTransformKeyCode(Time.fixedDeltaTime);
    }


    void Update()
    {
        GetPlayerWantedDirectionWithKeyCode();
    }
} */



    public class Walkv2 : MonoBehaviour 
{
        [SerializeField] float runSpeed;
        Rigidbody2D myRB;
        Animator animMarioLarge;

        // Start is called before the first frame update
        void Start() {
            myRB = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update() {
            Run();
            // spriteFlip();

        }

        private void Run() {
            float controlThrow = Input.GetAxis("Horizontal"); // value between -1 to +1
            Vector2 playerVeloctity = new Vector2(controlThrow * runSpeed, myRB.velocity.y);
            myRB.velocity = playerVeloctity;

            bool playerIsMovingHorizontal = Mathf.Abs(myRB.velocity.x) > Mathf.Epsilon;
            //animMarioLarge.SetBool("Running", playerIsMovingHorizontal);


        }

        /* private void spriteFlip() 
         {
             bool playerIsMovingHorizontal = Mathf.Abs(myRB.velocity.x) > Mathf.Epsilon;
         // flip sprite on horizontal axis

             if (playerIsMovingHorizontal)
             {
                 transform.localScale = new Vector2(Mathf.Sign(myRB.velocity.x), 1f);
             }


         } */

    }
