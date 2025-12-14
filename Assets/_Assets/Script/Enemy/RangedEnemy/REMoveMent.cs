using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REMoveMent : MoveMent
{
    //[SerializeField] private Animator animator;
    //public float speed = 0.2f;
    //public Transform rePos1;
    //public Transform rePos2;
    //public bool isPos1 = true;

    //private float timeMovement = 5f;
    //private float waitTime = 3f;
    //private float timer = 0f;
    //private bool isMove = true;

    //public Vector3 positionA;
    //public Vector3 positionB;

    //private void Start()
    //{
    //    positionA = rePos1.position;
    //    positionB = rePos2.position;

    //    if (animator == null) 
    //        animator = GetComponent<Animator>();
    //    timer = timeMovement;
    //}
    //private void FixedUpdate()
    //{
    //    if (isMove)
    //    {
    //        timer -= Time.fixedDeltaTime;
    //        if (timer < 0)
    //        {
    //            timer = waitTime;
    //            isMove = false;
    //        }
    //          this._MoveMent();
    //    }
    //    else if (!isMove)
    //    {
    //        timer -= Time.fixedDeltaTime;
    //        if(timer < 0)
    //        {
    //            timer = timeMovement;
    //            isMove = true;
    //        }
    //            animator.SetBool("MoveMent", false);
    //        return;
    //    }

    //}
    //public void _MoveMent()
    //{
    //    if (transform.position.x != positionA.x && isPos1)
    //    {
    //        Move(positionA);
    //    }
    //    else if (transform.position.x == positionA.x && isPos1)
    //    {
    //        SetScale(-1);
    //        isPos1 = false;
    //    }
    //    else if (transform.position.x != positionB.x && !isPos1)
    //    {
    //        Move(positionB);
    //    }
    //    else if (transform.position.x == positionB.x && !isPos1)
    //    {
    //        SetScale(1);
    //        isPos1 = true;
    //    }
    //}
    //void SetScale(float scale)
    //{
    //    transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    //}
    //public void Move(Vector2 pos)
    //{
    //    animator.SetBool("MoveMent", true);
    //    transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.fixedDeltaTime);
    //}

    [SerializeField] private Animator animator;
    private float timeMovement = 5f;
    private float waitTime = 3f;
    private float timer = 0f;
    private bool isMove = true;

    protected override void Start()
    {
        base.Start();
        if (animator == null)
            animator = GetComponent<Animator>();
        timer = timeMovement;
    }
    protected override void FixedUpdate()
    {
        if (isMove)
        {
            timer -= Time.fixedDeltaTime;
            if (timer < 0)
            {
                timer = waitTime;
                isMove = false;
            }
            this.Redirect();
        }
        else if (!isMove)
        {
            timer -= Time.fixedDeltaTime;
            if (timer < 0)
            {
                timer = timeMovement;
                isMove = true;
            }
            animator.SetBool("MoveMent", false);
            return;
        }
    }
    protected override void Move(Vector2 pos)
    {
        animator.SetBool("MoveMent", true);
        transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.fixedDeltaTime);
    }
}
