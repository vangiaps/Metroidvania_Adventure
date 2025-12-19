using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Animation_Event animation_Event;

    protected int comboIndex = 0;
    protected float lastAttackTime;
    public float comboResetTime = 1f;
    private void Start()
    {
        if (animation_Event == null)
            animation_Event = GetComponent<Animation_Event>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    protected void Update()
    {
        this.GetInput();

    }
    protected void GetInput()
    {
        if (Time.time - lastAttackTime > comboResetTime) comboIndex = 0;
            // Attack []
        if (InputManager.Instance.AttackInput() && !animation_Event.IsAttack)
        {
            this.Attack();
        }
        if (InputManager.Instance.AttackInput1() && !animation_Event.IsAttack)
        {
            this.AttackUp();
        }
        if (InputManager.Instance.AttackInput2() && !animation_Event.IsAttack)
        {
            this.AttackDown();
        }

    }

    public void Attack()
    {
        lastAttackTime = Time.time;
        comboIndex++;
        if (comboIndex > 4) comboIndex = 1;
        animator.SetTrigger("Attack" + comboIndex);
    }
    public void AttackDown()
    {
        animator.SetTrigger("AttackDown");
        AudioManager.Instance.Attack(2);
    }  
    public virtual void AttackUp()
    {

    }
    protected virtual void UseSkill()
    {

    }
}
