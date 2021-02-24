using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
            return;
        
        if(target.position.x > transform.position.x || target.position.y > transform.position.y)
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
        
    }
}
