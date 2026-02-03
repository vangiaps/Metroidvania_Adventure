using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEMoveMent : MoveMent
{
    private float timeMovement = 5f;
    private float waitTime = 3f;
    private float timer = 0f;
    private bool isMove = true;
    public float runSpeed = 0.4f;

    public bool detected;
    public float rayDistance = 2f;
    public LayerMask layer;
    public Transform playerPos;
    protected override void Update()
    {
        StandWait();
        TargetDetection();
    }
    public override void StandWait()
    {
        if (detected) return;

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
        animator.SetFloat("movement", 0.5f);
        base.Move(pos);
    }

    protected void TargetDetection()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayDistance, layer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, layer);
        if(hitRight || hitLeft)
        {
            detected = true;
            if (hitRight != null)
            {
                playerPos = hitRight.transform;
                MoveTo(playerPos);
            }
            else if (hitLeft != null)
            {
                playerPos = hitLeft.transform;
                MoveTo(playerPos);
            }
        }
        Debug.DrawRay(transform.position,Vector2.left*rayDistance, Color.green);
        Debug.DrawRay(transform.position,Vector2.right*rayDistance, Color.green);
    }
    protected void MoveTo(Transform player)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, runSpeed * Time.deltaTime);
    }
}
