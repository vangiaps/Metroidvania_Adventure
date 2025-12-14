using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1AnimationEvent : Animation_Event
{
    public Player1Audio player1Audio;

    private void Start()
    {
        if (player1Audio == null)
            player1Audio = GetComponent<Player1Audio>();
    }
    public override void Appear()
    {
        AudioManager.Instance.PlaySfx(player1Audio.appearSound);
    }
}
