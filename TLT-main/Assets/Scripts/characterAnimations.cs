using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimations : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool sprintPressed = Input.GetKey("left shift");
        bool isRunning = anim.GetBool("IsRunning");
        
        bool forwardPressed = Input.GetKey("w");
        bool IsWalking = anim.GetBool("IsWalking");


        if (!IsWalking && forwardPressed)
        {
            anim.SetBool("IsWalking",true);
        }
        if (IsWalking && !forwardPressed)
        {
            anim.SetBool("IsWalking",false);
        }

        if (!isRunning && (forwardPressed && sprintPressed) )
        {
            anim.SetBool("IsRunning",true);
        }
        if (isRunning && (!forwardPressed || !sprintPressed))
        {
            anim.SetBool("IsRunning",false);
        }
    }
}
