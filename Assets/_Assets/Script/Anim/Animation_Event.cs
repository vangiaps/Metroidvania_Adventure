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
}
