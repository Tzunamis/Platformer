using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{

    public bool isCrouched;
    public bool isJumping;
    public bool isRunning;
    Walkv2 walk;
    Jump jump;
    SpriteRenderer mySP;
    Animator myAnim;
    BoxCollider2D bc;

    private void Awake()
    {
        walk = GetComponent<Walkv2>();
        jump = GetComponent<Jump>();
        bc = GetComponent<BoxCollider2D>();
        myAnim = transform.Find("Sprite").GetComponent<Animator>();
        mySP = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // isCrouched = false;
        isJumping = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        // isCrouched = Input.GetKey(KeyCode.DownArrow);

        //walk.enabled = !isCrouched;
        //walk.SetInputLock(isCrouched);
        isJumping = Input.GetKey(KeyCode.UpArrow);

         // SyncAnimator();
    }

    /* void SyncAnimator()    
    {
        if (walk.GetCurrentSpeed() < 0)
        {
            myAnim.SetBool("Running", true);
            mySP.flipX = true;
            myAnim.SetBool("Running", true);
        }
        else if (walk.GetCurrentSpeed() > 0)
        {
            mySP.flipX = false;
        }
        else
        {
            myAnim.SetBool("Running", false);
        }

  
        myAnim.SetBool("Crouching", isCrouched);
      
       
        
        myAnim.SetBool("Jumping", jump.IsJumping() && !isCrouched);
        

        if(walk.inFightingAgainstSlideMode)
        {
            mySP.flipX = !mySP.flipX;
        }
        myAnim.SetBool("Sliding", walk.inFightingAgainstSlideMode); 
    }
    */

}
