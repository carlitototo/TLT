using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    playerController PlayerController;
    void Awake()
    {
        PlayerController = GetComponentInParent<playerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }
        
        PlayerController.SetGroundedState(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }
        
        PlayerController.SetGroundedState(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }
        
        PlayerController.SetGroundedState(true);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }
        
        PlayerController.SetGroundedState(true);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }
        
        PlayerController.SetGroundedState(false);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }
        
        PlayerController.SetGroundedState(true);
    }
}
