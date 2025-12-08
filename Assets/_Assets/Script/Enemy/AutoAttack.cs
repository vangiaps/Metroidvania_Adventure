using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float timeBetweenAttack = 2f;
    private float timer = 0f;
    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > this.timeBetweenAttack)
        {
            this.DoAttack();
            timer = 0f;
        }
    }
    private void DoAttack()
    {
        animator.SetTrigger("Attack");
    }
}
