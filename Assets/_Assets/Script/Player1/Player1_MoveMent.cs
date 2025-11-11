using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_MoveMent : Move
{

    // double jump
    public override void GetInput()
    {
        if (InputManager.Instance.JumpInput() && canDoubleJump == true)
        {
            jumpPoint = transform.position;
            this.Jump();
            AudioManager.Instance.PlaySfx(AudioManager.Instance.doubleJumpSound);
            canDoubleJump = false;
        }
        base.GetInput();
    }
}
