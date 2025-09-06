using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    public float speed = 0.2f;
    public Transform pos1;
    public Transform pos2;
    public bool isPos1 = true;

    private void FixedUpdate()
    {
        this.Redirect();
    }
    public void Redirect()
    {
        if (transform.position.x != pos1.position.x && isPos1)
        {
            Move(pos1.position);
        }
        else if (transform.position.x == pos1.position.x && isPos1)
        {
            SetScale(-1);
            isPos1 = false;
        }
        else if (transform.position.x != pos2.position.x && !isPos1)
        {
            Move(pos2.position);
        }
        else if (transform.position.x == pos2.position.x && !isPos1)
        {
            SetScale(1);
            isPos1 = true;
        }
    }
    void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
    public void Move( Vector2 pos)
    {
        transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.fixedDeltaTime);
    }
}
