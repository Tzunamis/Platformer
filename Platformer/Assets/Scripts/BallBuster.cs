using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBuster : MonoBehaviour
{
   Rigidbody2D rb;
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D marble)
    {
        if (marble.gameObject.tag == "marble")
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
