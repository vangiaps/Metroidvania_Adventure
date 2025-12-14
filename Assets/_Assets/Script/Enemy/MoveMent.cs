using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveMent : MonoBehaviour
{
    public float speed = 0.2f;
    public Transform pos1;
    public Transform pos2;
    public bool isPos1 = true;

    protected Vector3 positionA;
    protected Vector3 positionB;

    protected virtual void Start()
    {
        //lay vi tri co dinh cua pos1 va 2 
        positionA = pos1.position;
        positionB = pos2.position;
    }

    protected virtual void FixedUpdate()
    {
        this.Redirect();
    }
    public void Redirect()
    {
        if (transform.position.x != positionA.x && isPos1)
        {
            Move(positionA);
        }
        else if (transform.position.x == positionA.x && isPos1)
        {
            SetScale(-1);
            isPos1 = false;
        }
        else if (transform.position.x != positionB.x && !isPos1)
        {
            Move(positionB);
        }
        else if (transform.position.x == positionB.x && !isPos1)
        {
            SetScale(1);
            isPos1 = true;
        }
    }
    void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
    protected virtual void Move( Vector2 pos)
    {
        transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.fixedDeltaTime);
    }
}
