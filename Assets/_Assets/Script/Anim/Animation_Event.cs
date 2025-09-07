using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Event : MonoBehaviour
{
    public Move move;
    public Player_anim player_Anim;
    public bool IsAttack;

    private void Awake()
    {
        move = GetComponent<Move>();
        player_Anim = GetComponent<Player_anim>();
    }
    public void Stop()
    {
        move.speed = 0;
    }   
    public void Run()
    {
        move.speed = move.baseSpeed;
    }
    public void IsRunTurnF()
    {
        player_Anim.isRunTurn = false;
    }     
    public void IsRunTurnT()
    {
        player_Anim.isRunTurn = true;
    }  
    public void StartAttack()
    {
        IsAttack = true;
    }
    public void EndAttack()
    {
        IsAttack = false;
    }

    // audio sound
    public void SoundAttack1()
    {
        AudioManager.Instance.Attack(0);
    }   
    public void SoundAttack2()
    {
        AudioManager.Instance.Attack(1);
    }    
    public void SoundAttack3()
    {
        AudioManager.Instance.Attack(2);
    }   
    public void SoundAttack4()
    {
        AudioManager.Instance.Attack(3);
    }
    public void FootStep1()
    {
        AudioManager.Instance.Footstep(0);
    }    
    public void FootStep2()
    {
        AudioManager.Instance.Footstep(1);
    }   
    public void FootStep3()
    {
        AudioManager.Instance.Footstep(2);
    } 
    public void FootStep4()
    {
        AudioManager.Instance.Footstep(3);
    } 
    public void Appear()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Instance.appearSound);
    }
}
