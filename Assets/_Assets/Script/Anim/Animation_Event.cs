using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Event : MonoBehaviour
{
    public Move move;
    public Player_anim player_Anim;
    public bool IsAttack = false;

    protected virtual void Awake()
    {
        move = GetComponent<Move>();
        player_Anim = GetComponent<Player_anim>();
    }
    public virtual void Stop()
    {
        move.speed = 0;
    }   
    public virtual void Run()
    {
        move.speed = move.baseSpeed;
    }
    public virtual void IsRunTurnF()
    {
        player_Anim.isRunTurn = false;
    }     
    public virtual void IsRunTurnT()
    {
        player_Anim.isRunTurn = true;
    }  
    public virtual void StartAttack()
    {
        IsAttack = true;
    }
    public virtual void EndAttack()
    {
        IsAttack = false;
    }

    // audio sound
    public virtual void PlayAttackSound(int index)
    {
        if(AudioManager.Instance != null && index >= 0 && index< AudioManager.Instance.attackSound.Length)
        {
            AudioManager.Instance.Attack(index);
        }
    }
    public virtual void PlayFootstepSound(int index)
    {
        if (AudioManager.Instance != null && index >= 0 && index < AudioManager.Instance.footstepSoound.Length)
        {
            AudioManager.Instance.Footstep(index);
        }
    }
    public virtual void Appear()
    {   

    }
}
