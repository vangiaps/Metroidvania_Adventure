using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Anim : Player_anim
{
    public override void TriggerJump()
    {
        animator.SetTrigger("Jump");
    }
}
