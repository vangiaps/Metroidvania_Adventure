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
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject arroePrefab;
    [SerializeField] private MoveMent moveMent;
    private float arrowSpeed = 3f;

    protected Transform playerPosition;
    protected Vector2 direction;
    float currentScale;
    private bool hasSavedScale = false;


    public float fireRate = 0.5f;
    protected float lastShotTime;

    protected void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (moveMent == null)
            moveMent = GetComponent<MoveMent>();
    }
    protected void Update()
    {
        DetectPlayer();
        if (playerPosition != null)
        {
            Attack();
        }
    }

    protected void DetectPlayer()
    {
        // Tạo một vòng tròn vô hình quét xem có Collider nào thuộc layer Player nằm trong đó không
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange, layerMask);
        if (hit != null)
        {
            playerPosition = hit.transform;
            if (!hasSavedScale)
            {
                moveMent.currentSpeed = 0f;
                currentScale = transform.localScale.x;
                hasSavedScale = true;
            }

        }
        else
        {
            playerPosition = null;
        }
    }

    protected void Attack()
    {
        // Thời gian chờ (Cooldown) = (1giây)/(Số viên đạn)
        if (Time.time > lastShotTime + 1f / fireRate)
        {
            float distance = transform.position.x - playerPosition.position.x;
            float scale = distance > 0 ? 1 : -1;
            moveMent.SetScale(scale);
            // tinh huong tu sung -> player
            direction = playerPosition.position - attackPoint.position;
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
        GameObject arrow = Instantiate(arroePrefab, attackPoint.position, rotation);

        // gan van toc 
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.velocity = arrow.transform.right * arrowSpeed;
        if (hasSavedScale && playerPosition == null) 
        {
            moveMent.SetScale(currentScale);
            moveMent.currentSpeed = moveMent.speed;
            hasSavedScale = false;
        }
    }

    void OnDrawGizmos()
    {
        // Vẽ vòng tròn debug màu xanh
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
