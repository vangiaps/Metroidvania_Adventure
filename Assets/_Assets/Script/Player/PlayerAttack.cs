using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Animation_Event animation_Event;

    private int comboIndex = 0;
    private float lastAttackTime;
    public float comboResetTime = 1f;
    public int damage = 1;
    private void Update()
    {
        this.GetInput();
    }
    void GetInput()
    {
        if (Time.time - lastAttackTime > comboResetTime) comboIndex = 0;
            // Attack []
        if (InputManager.Instance.AttackInput() && !animation_Event.IsAttack)
        {
            if (!InputManager.Instance.AttackInput2())
            {
            this.Attack();

            }
        }
        if (InputManager.Instance.AttackInput2() && InputManager.Instance.AttackInput() && !animation_Event.IsAttack)
        {
            this.AttackDown();
        }
        if (InputManager.Instance.AttackInput2() && InputManager.Instance.AttackInput1() && !animation_Event.IsAttack)
        {
            this.AttackUp();
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
    }  
    public void AttackUp()
    {
        animator.SetTrigger("AttackUp");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(this.damage);
        }
    }
}
