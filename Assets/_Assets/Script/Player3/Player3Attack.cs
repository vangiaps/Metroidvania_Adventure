using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Attack : PlayerAttack
{
    public Player3Audio player3Audio;

    private void Start()
    {
        if (player3Audio == null)
            player3Audio = GetComponent<Player3Audio>();
    }
    public override void AttackUp()
    {
        animator.SetTrigger("AttackUp");
    }

}
