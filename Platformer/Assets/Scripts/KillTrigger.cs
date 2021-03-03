using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillTrigger : MonoBehaviour
{
    Rigidbody2D rb;
    public bool DestroyObjects;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.gameObject.name == "Player")
        {
            SceneManager.LoadScene(0);
            Debug.Log("Player Died, Resetting Scene");
        }
        else if (DestroyObjects)
        {
            Destroy(collided.gameObject);
        }
    }
}
