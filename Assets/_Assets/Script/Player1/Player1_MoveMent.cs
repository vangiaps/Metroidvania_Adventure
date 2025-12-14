using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_MoveMent : Move
{
    protected Player1Audio player1Audio;
    protected Player1Anim player1Anim;
    public bool isJump;

    private void Start()
    {
        if (player1Audio == null)
            player1Audio = GetComponent<Player1Audio>();
    }
    protected override void Update()
    {
        base.Update();
        Check();
    }
    // double jump
    public override void GetInput()
    {
        if (InputManager.Instance.JumpInput() && _isGrounded)
        {
            this.Jump();
            this.canDoubleJump = true;
        }
         else if (InputManager.Instance.JumpInput() && canDoubleJump == true)
        {
            //jumpPoint = transform.position;
            this.Jump();
            canDoubleJump = false;
        }
        base.GetInput();
    }
    protected virtual void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        player_Anim.TriggerJump();
        //AudioManager.Instance.PlaySfx(player1Audio.jumpSound);
        AudioManager.Instance.PlaySfx(player1Audio.jumpSound);
        isJump = true;
    }
    // goi khi cham dat nhung animation jump van chay 
    void Check()
    {
        if (isJump == true && _isGrounded)
        {
            player_Anim.TriggerIsGround();
        }
    }
}
