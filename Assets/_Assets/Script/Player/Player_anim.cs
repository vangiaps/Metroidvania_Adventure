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
        //this.SetAnimator();
        this.SetScale();
    }
    
    public void SetSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }
    //nhay
    public void TriggerJump()
    {
        animator.SetTrigger("Jump");
    }
    public void TriggerDash(bool isDash)
    {
        animator.SetBool("Dash", isDash);
    }
    //ham sua loi khi cham dat nhung animation khong chuyen tu jump sang fall hay idle
    public void TriggerIsGround()
    {
        animator.SetTrigger("isGround");
    }

    // lay_gia_tri_van_toc_roi_va_co_cham_dat_khong
    public void SetBoolFall(float velocity , bool isGrounded)
    {
        if (velocity < 0 && !isGrounded)
        {
            animator.SetBool("Fall", true);
        }
        else
        {
            animator.SetBool("Fall", false);
        }
    }


    //*/PHAN_DAU_TIEN*/

    //public virtual void SetAnimator()
    //{
    //    if (move._isGrounded == true)
    //    {
    //        animator.SetFloat("Speed", move.direction.magnitude);
    //    }
    //    else
    //    {
    //        animator.SetFloat("Speed", 0);

    //    }
    //    //
    //    if (InputManager.Instance.JumpInput() && isRunTurn == false)
    //    {
    //        animator.SetTrigger("DoubleJump");
    //    }
    //    //
    //    if (move.isDashing)
    //    {
    //        animator.SetTrigger("Dash");
    //    } 
    //    //
    //    if(move.rb.velocity.y < 0 && !move._isGrounded)
    //    {
    //        animator.SetBool("Fall", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("Fall", false);
    //    }
    //}

    public virtual void SetScale()
    {
        
        if (move.direction.x !=0 )
        {
            float scale = move.direction.x > 0 ? 1 : -1;

            //animation quay lai va bat dau chay
            //if (scale != lastDirection && move.direction.magnitude > 0)
            //{
            //   animator.SetTrigger("RunTurn");
            //}
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            lastDirection = scale;
        }

    }
}
