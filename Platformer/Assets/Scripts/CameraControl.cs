﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    public float LeftEdge;
    public float BottomEdge;
    public float TopEdge;
    public float RightEdge;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player.transform.position.x > LeftEdge && Player.transform.position.x < RightEdge)
        {
            transform.position = new Vector3(Player.transform.position.x, transform.position.y, -2);
        }
        
        if (Player.transform.position.y > BottomEdge && Player.transform.position.y < TopEdge)
        {
            transform.position = new Vector3(transform.position.x, Player.transform.position.y, -2);
        }
    }
}
