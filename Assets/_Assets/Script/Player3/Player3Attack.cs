using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Attack : PlayerAttack
{
    public Player3Audio player3Audio;
    public float firingRange = 2f;
    public float speed = 3f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject fireball;


    private void Start()
    {
        if (player3Audio == null)
            player3Audio = GetComponent<Player3Audio>();
    }
    public override void AttackUp()
    {
        animator.SetTrigger("AttackUp");
    }
    protected override void UseSkill()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, firingRange, layerMask);
        if (hit == null) return;
        Vector2 direction = hit.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        GameObject fireBridge = Instantiate(fireball, transform.position, rotation);
        Rigidbody2D rb = fireBridge.GetComponent<Rigidbody2D>();
        rb.velocity = fireBridge.transform.right * speed;

        animator.SetTrigger("SkillF");
        Debug.Log("ban");
    }
    void OnDrawGizmos()
    {
        // Vẽ vòng tròn debug màu xanh
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, firingRange);
    }
}
