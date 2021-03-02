using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillTrigger : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.name == "Player")
        {
            SceneManager.LoadScene(0);
            Debug.Log("Player Died, Resetting Scene");
        }
    }
}
