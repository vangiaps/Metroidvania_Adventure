using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_anim : MonoBehaviour
{
    public Animator animator;
    public Move move;
    public Animation_Event animation_Event;

    public Vector3 secondaryDirection;
    private float lastDirection = 0;
    public bool isRunTurn = false;
    private void Awake()
    {
        move = GetComponent<Move>();
        animation_Event = GetComponent<Animation_Event>();
    }

    private void Update()
    {
        this.SetAnimator();
        this.SetScale();
    }
    
    public virtual void SetAnimator()
    {
        if (move._isGrounded == true)
        {
            animator.SetFloat("Speed", move.direction.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);

        }
        //
        if (InputManager.Instance.JumpInput() && isRunTurn == false)
        {
            animator.SetBool("DJ", true);
            animator.SetTrigger("DoubleJump");
        }
        else if(move._isGrounded == true)
        {
            animator.SetBool("DJ", false);
        }
        //
        if (move.isDashing)
        {
            animator.SetTrigger("Dash");
        } 
    }
    public virtual void SetScale()
    {
        
        if (move.direction.x !=0 )
        {
            float scale = move.direction.x > 0 ? 1 : -1;
            if (scale != lastDirection && move.direction.magnitude > 0)
            {
               animator.SetTrigger("RunTurn");
            }
            else if (move._isGrounded)
            {
                    animator.SetTrigger("IdleToRun");
            }
         transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            lastDirection = scale;
        }

    }
}
