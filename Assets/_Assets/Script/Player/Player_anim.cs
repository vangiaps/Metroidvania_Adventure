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
    protected float lastDirection = 0;
    public bool isRunTurn = false;
    protected void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (move == null)
            move = GetComponent<Move>();
        if (animation_Event == null)
            animation_Event = GetComponent<Animation_Event>();
    }

    protected void Update()
    {
        this.SetScale();
    }
    
    public void SetSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }
    public virtual void TriggerJump()
    {

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
        //if (velocity <= 0 && !isGrounded)
        //{
        //    animator.SetBool("Fall", true);
        //}
        //else if (isGrounded)
        //{
        //    animator.SetBool("Fall", false);
        //}
        animator.SetFloat("yVelocity", velocity);
    }

    public virtual void SetScale()
    {
        if (move.direction.x !=0 )
        {
            float scale = move.direction.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            lastDirection = scale;
        }
    }
}
