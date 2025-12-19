using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REMoveMent : MoveMent
{
    private float timeMovement = 5f;
    private float waitTime = 3f;
    private float timer = 0f;
    private bool isMove = true;

    protected override void Update()
    {
        StandWait();
    }
    public override void StandWait()
    {
        if (isMove)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = waitTime;
                isMove = false;
            }
            this.Redirect();
        }
        else if (!isMove)
        {
            animator.SetFloat("movement", 0f);
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = timeMovement;
                isMove = true;
            }
            return;
        }
    }
    protected override void Move(Vector2 pos)
    {
        animator.SetFloat("movement", 1);
        base.Move(pos);
    }
}
