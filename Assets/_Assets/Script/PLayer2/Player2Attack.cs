using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : PlayerAttack
{
    public Player2Audio player2Audio;

    private void Start()
    {
        if (player2Audio == null)
            player2Audio = GetComponent<Player2Audio>();
    }
    public override void AttackUp()
    {
        animator.SetTrigger("AttackUp");
        AudioManager.Instance.PlaySfx(player2Audio.attackUpSound);
    }
}
