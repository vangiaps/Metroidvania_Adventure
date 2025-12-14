using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2AnimationEvent : Animation_Event
{
    public Player2Audio player2Audio;

    private void Start()
    {
        if (player2Audio == null)
            player2Audio = GetComponent<Player2Audio>();
    }
    public override void Appear()
    {
        AudioManager.Instance.PlaySfx(player2Audio.appearSound);
    }
}
