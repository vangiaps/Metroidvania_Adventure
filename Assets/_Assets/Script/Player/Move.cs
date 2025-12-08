using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    public Rigidbody2D rb;

    public Player_anim player_Anim;
    [Header("Cac_gtri_cho_chuc_nang_nhay_va_di_chuyen")]
    public float baseSpeed = 2f;
    public float speed;
    public float jumpForce = 2f;
    public bool canDoubleJump;
    //public Vector3 jumpPoint;
    [Header("Thoi_gian_Dash_va_thoi_gian_hoi_dash")]
    public float dashSpeed = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 0.5f;
    public bool isDashing = false;
    float lastDashTime = -999f;

    [Header("Raycast_de_phat_hien_cham_mat_dat_va_tuong")]
    public Vector2 direction;
    Vector2 boxSize;

    public Transform groundCheck;
    public float groundDistance = 0.17f;
    public LayerMask groundLayer;
    public bool _isGrounded;
    
    public Transform wallCheckUp;
    public Transform wallCheckDown;
    public float wallDistance = 0.1f;
    bool _isWallUp;
    bool _isWallDown;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player_Anim = gameObject.GetComponent<Player_anim>();
    }
    private void Start()
    {
        this.speed = this.baseSpeed;
        
    }
    protected virtual void Update()
    {
        // Nếu object này đã bị hủy hoặc không còn tồn tại -> Dừng ngay
        if (this == null || transform == null) return;
        this.boxSize = GetComponent<Collider2D>().bounds.size;
        this.GetInput();
        this.Scale();
        this.RayCastCheck_Jump();
        RayCastCheck_Wall();
    }

    public void Scale()
    {
        player_Anim.SetBoolFall(rb.velocity.y, this._isGrounded);
    }

    private void FixedUpdate()
    {
        this.Movement();
    }
    
    public virtual void GetInput()
    {
        // Movement
        this.direction = InputManager.Instance.GetMovementInput();

        // dash
        if (InputManager.Instance.DashInput() && Time.time > lastDashTime + dashCooldown)
        {
            Vector2 dir = new(InputManager.Instance.GetMovementInput().x, 0f);
            if (dir.sqrMagnitude == 0) dir = Vector2.right * Mathf.Sign(transform.localScale.x);
            StartCoroutine(DoDash(dir.normalized));
            lastDashTime = Time.time;
        }
    }
    void Movement()
    {
        //NEU_DANG_DASH_THI_HUY_DI_CHUYEN
        if (isDashing) return;

        //CHAM_TUONG_THI_DUNG_LAI
        //CHI_CHAY_ANIMATION
        if (_isWallUp ||_isWallDown)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        }
        //ANIMATION
        player_Anim.SetSpeed(direction.sqrMagnitude);

    }
    private IEnumerator DoDash(Vector2 dir)
    {
        isDashing = true;
        //sound
        AudioManager.Instance.PlaySfx(AudioManager.Instance.dashSound);
        //ANIMATION
        player_Anim.TriggerDash(isDashing);
        //
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(dir.x * dashSpeed, rb.velocity.y);
        float t = 0f;
        while (t < dashDuration)
        {
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        rb.gravityScale = originalGravity;
        // Sau dash: dừng ngang hoặc trả về velocity bình thường
        rb.velocity = new Vector2(0f, rb.velocity.y);
        isDashing = false;
        player_Anim.TriggerDash(isDashing);
    }

    //KIEM_TRA_CHAM_DAT
    void RayCastCheck_Jump()
    {
        //RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f ,Vector2.down, groundDistance, groundLayer);
        //_isGrounded = hit.collider != null;
        _isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.17f, groundLayer);

        Debug.DrawRay(transform.position, groundDistance * Vector2.down, Color.red);
    }
    //KHIEM_TRA_CO_CHAM_TUONG
    void RayCastCheck_Wall()
    {
        _isWallUp = Physics2D.Raycast(wallCheckUp.position, Vector2.right* Mathf.Sign(Input.GetAxisRaw("Horizontal")), wallDistance, groundLayer);
        _isWallDown = Physics2D.Raycast(wallCheckDown.position, Vector2.right* Mathf.Sign(Input.GetAxisRaw("Horizontal")), wallDistance, groundLayer);


        Debug.DrawRay(wallCheckUp.position, wallDistance * Vector2.right * Mathf.Sign(Input.GetAxisRaw("Horizontal")), Color.cyan);
        Debug.DrawRay(wallCheckDown.position, wallDistance * Vector2.right * Mathf.Sign(Input.GetAxisRaw("Horizontal")), Color.cyan);
    }

}
