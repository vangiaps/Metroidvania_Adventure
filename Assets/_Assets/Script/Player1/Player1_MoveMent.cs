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
        if (player1Anim == null)
            player1Anim = GetComponent<Player1Anim>();
    }
    protected override void Update()
    {
        base.Update();
        Check();
    }
    // double jump
    public override void GetInput()
    {
        base.GetInput();
        if (InputManager.Instance.JumpInput() && canDoubleJump == true && !_isGrounded)
        {
            this.DoubleJump();
            canDoubleJump = false;
        }
    }
    protected void DoubleJump()
    {
        player1Anim.TriggerJump();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        AudioManager.Instance.PlaySfx(player1Audio.jumpSound);
        isJump = true;
    }
    // goi khi cham dat nhung animation jump van chay 
    void Check()
    {
        if (isJump == true && _isGrounded)
        {
            player_Anim.TriggerIsGround();
            isJump = false;
        }
    }
}
