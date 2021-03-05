using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTutUI : MonoBehaviour
{
    CanvasGroup cg;
    public float FadeSpeed;
    public float LoadDistance;
    public GameObject Gnome;
    public GameObject Ball;
    Vector2 CanvasLocation;
    Vector2 GnomeLocation;
    Vector2 BallLocation;
    Vector2 DistanceVector;
    Vector2 BallDistanceVector;
    public bool NeedsTutorial = true;
    bool beenShown = false;
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
    }

    void Update()
    {
        if (NeedsTutorial)
        {
            CanvasLocation = gameObject.transform.position;
            GnomeLocation = Gnome.transform.position;
            BallLocation = Ball.transform.position;
            DistanceVector = CanvasLocation - GnomeLocation;
            BallDistanceVector = BallLocation - GnomeLocation;
            if (DistanceVector.magnitude <= LoadDistance)
            {
                Appear();
                beenShown = true;
            }
            else
            {
                Disappear();
            }
            if (BallDistanceVector.magnitude <= LoadDistance)
            {
                NeedsTutorial = false;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Appear()
    {
        if (cg.alpha != 1)
        {
            cg.alpha += FadeSpeed;
        }

    }

    void Disappear()
    {
        if (cg.alpha != 0)
        {
            cg.alpha -= FadeSpeed;
        }
        else if (beenShown)
        {
            NeedsTutorial = false;
        }
    }
}
