using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public bool InputEnabled = true;
    public float NukeSpeed;
    bool ButtonPressed;
    bool Launchable = false;
    bool DonePanning;
    GameObject Nuke;
    GameObject Camera;
    CameraControl CC;
    void Start()
    {
        Nuke = GameObject.Find("Nuke (1)");
        Camera = GameObject.Find("Main Camera");
        CC = Camera.GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ButtonPressed)
        {
            ButtonDepress();
        }
        if (Launchable)
        {
            if (!DonePanning)
            {
                PanCamera();
            }
            else
            {
                LaunchNuke();
            }
           
        }
    }
    void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.name == "Player")
        {
            InputEnabled = false;
            ButtonPressed = true;
        }
    }

    void LaunchNuke()
    {
        if(Nuke.transform.position.x >= 35)
        {
            Nuke.transform.position = new Vector3(Nuke.transform.position.x, Nuke.transform.position.y + NukeSpeed, Nuke.transform.position.z);
            NukeSpeed *= 1.01f;
        }
        else
        {
            Debug.Log("Game Won");
        }
    }

    void ButtonDepress()
    {
        if (gameObject.transform.position.y >= -3.17f)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
        }
        else
        {
            ButtonPressed = false;
            Launchable = true;
        }
    }
    void PanCamera()
    {
        CC.ActiveTracking = false;
        CC.Player = Nuke;
        Camera.transform.position = new Vector3(Mathf.Round(Camera.transform.position.x * 10f)/10f, Mathf.Round(Camera.transform.position.y * 10f) / 10f, Mathf.Round(Camera.transform.position.z * 10f) / 10f);
        if(Camera.transform.position.x < Nuke.transform.position.x)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x + 0.1f, Camera.transform.position.y, Camera.transform.position.z);
        }
        if (Camera.transform.position.y < Nuke.transform.position.y)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y + 0.1f, Camera.transform.position.z);
        }
        if (Camera.transform.position.x > Nuke.transform.position.x)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x - 0.1f, Camera.transform.position.y, Camera.transform.position.z);
        }
        /*if (Camera.transform.position.y > Nuke.transform.position.y)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 0.1f, Camera.transform.position.z);
        }*/

        if (Camera.transform.position.x == Nuke.transform.position.x && Camera.transform.position.y >= Nuke.transform.position.y)
        {
            CC.ActiveTracking = true;
            CC.TopEdge = 30.0f;
            DonePanning = true;
        }
    }
}
