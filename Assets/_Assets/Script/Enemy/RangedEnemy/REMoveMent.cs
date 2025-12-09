using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REMoveMent : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public float speed = 0.2f;
    public Transform rePos1;
    public Transform rePos2;
    public bool isPos1 = true;

    private float timeMovement = 5f;
    private float waitTime = 3f;
    private float timer = 0f;
    private bool isMove = true;

    private void Start()
    {
        if (animator == null) 
            animator = GetComponent<Animator>();
        timer = timeMovement;
    }
    private void FixedUpdate()
    {
        if (isMove)
        {
            timer -= Time.fixedDeltaTime;
            if (timer < 0)
            {
                timer = waitTime;
                isMove = false;
            }
              this._MoveMent();
        }
        else if (!isMove)
        {
            timer -= Time.fixedDeltaTime;
            if(timer < 0)
            {
                timer = timeMovement;
                isMove = true;
            }
                animator.SetBool("MoveMent", false);
            return;
        }
    }
    public void _MoveMent()
    {
        if (transform.position.x != rePos1.position.x && isPos1)
        {
            Move(rePos1.position);
        }
        else if (transform.position.x == rePos1.position.x && isPos1)
        {
            SetScale(-1);
            isPos1 = false;
        }
        else if (transform.position.x != rePos2.position.x && !isPos1)
        {
            Move(rePos2.position);
        }
        else if (transform.position.x == rePos2.position.x && !isPos1)
        {
            SetScale(1);
            isPos1 = true;
        }
    }
    void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
    public void Move(Vector2 pos)
    {
        animator.SetBool("MoveMent", true);
        transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.fixedDeltaTime);
    }
}
