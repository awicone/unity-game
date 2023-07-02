using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometTail : MonoBehaviour
{
    public float speed = 10.0f;
    public float sprintSpeed = 20.0f;
    public TrailRenderer cometTail;
    public BasicBehaviour basicBehaviour;

    private bool isSprinting;

    void Start()
    {
        cometTail.emitting = false;
        isSprinting = false;
    }

    void Update()
    {
        // check if sprint key is down
        if(basicBehaviour.IsSprinting() && !isSprinting)
        {
            isSprinting = true;
            cometTail.emitting = true;
            Debug.Log("Sprinting");
        }
        // check if sprint key is up
        else if (!basicBehaviour.IsSprinting() && isSprinting)
        {
            isSprinting = false;
            cometTail.emitting = false;
            Debug.Log("Not Sprinting");
        }
    }
}
