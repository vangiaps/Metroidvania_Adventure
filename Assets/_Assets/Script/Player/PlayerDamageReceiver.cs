using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageReceiver : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
    public void OnHit(int damage)
    {
        animator.SetTrigger("Hit");
        HealManager.Instance.TakeDamage(damage);
        if (HealManager.Instance != null)
        {
            bool isDead = HealManager.Instance.isDie;

            if (isDead)
            {
                animator.SetTrigger("Die");
            }
        }
    }
}
