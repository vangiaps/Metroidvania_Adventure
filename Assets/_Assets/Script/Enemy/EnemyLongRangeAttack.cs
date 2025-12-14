using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLongRangeAttack : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject arroePrefab;
    private float arrowSpeed = 3f;

    private Transform playerPosition;
    private Vector2 direction;


    public float fireRate = 0.5f;
    protected float lastShotTime;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    private void Update()
    {
        DetectPlayer();
        if(playerPosition != null)
        {
            Attack();
        }
    }

    private void DetectPlayer()
    {
        // Tạo một vòng tròn vô hình quét xem có Collider nào thuộc layer Player nằm trong đó không
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange, layerMask);
        if(hit != null)
        {
            playerPosition = hit.transform;
        }
        else
        {
            playerPosition = null;
        }
    }

    private void Attack()
    {
        // Thời gian chờ (Cooldown) = (1giây)/(Số viên đạn)
        if (Time.time > lastShotTime + 1f / fireRate)
        {
            float distance = transform.position.x - playerPosition.position.x;
            Debug.Log(distance);
            float scale = distance > 0 ? 1 : -1;
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            // tinh huong tu sung -> player
            direction = playerPosition.position - firePoint.position;
            // goi anim -> goi ham shoot
            animator.SetTrigger("Shoot");
            lastShotTime = Time.time;
        }
    }
    public void Shoot()
    {
        // tinh goc xoay atan -> radian, chuyen tu radian ve do  
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // sinh mui ten 
        GameObject arrow = Instantiate(arroePrefab, firePoint.position, rotation);

        // gan van toc 
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.velocity = arrow.transform.right * arrowSpeed;

    }

    void OnDrawGizmos()
    {
        // Vẽ vòng tròn debug màu xanh
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
