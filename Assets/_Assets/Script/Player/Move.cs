using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;

    public float baseSpeed = 2f;
    public float speed;
    public float dashSpeed = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 0.5f;
    public float jumpForce = 2f;
    public bool canDoubleJump;
    public Vector3 jumpPoint;

    public bool isDashing = false;
    float lastDashTime = -999f;

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
    }
    private void Start()
    {
        this.speed = this.baseSpeed;
        
    }
    private void Update()
    {
        this.boxSize = GetComponent<Collider2D>().bounds.size;
        this.GetInput();
        this.RayCastCheck_Jump();
        RayCastCheck_Wall();
    }
    private void FixedUpdate()
    {
        this.Movement();
    }
    public void GetInput()
    {
        // Movement
        this.direction = InputManager.Instance.GetMovementInput();
        // Jump
        if (InputManager.Instance.JumpInput() && _isGrounded)
        {
            this.Jump();
        AudioManager.Instance.PlaySfx(AudioManager.Instance.jumpSound);
            canDoubleJump = true;
        }
        else if (InputManager.Instance.JumpInput() && canDoubleJump)
        {
            jumpPoint = transform.position;
            this.Jump();
            AudioManager.Instance.PlaySfx(AudioManager.Instance.doubleJumpSound);
            canDoubleJump = false;
        }
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
        if (isDashing) return;
        if (_isWallUp ||_isWallDown)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        }
    }
    void Jump()
    {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private IEnumerator DoDash(Vector2 dir)
    {
        isDashing = true;
        //sound
        AudioManager.Instance.PlaySfx(AudioManager.Instance.dashSound);
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
    }
    void RayCastCheck_Jump()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f ,Vector2.down, groundDistance, groundLayer);
        _isGrounded = hit.collider != null;

        Debug.DrawRay(transform.position, groundDistance * Vector2.down, Color.red);
    }void RayCastCheck_Wall()
    {
        _isWallUp = Physics2D.Raycast(wallCheckUp.position, Vector2.right* Mathf.Sign(Input.GetAxisRaw("Horizontal")), wallDistance, groundLayer);
        _isWallDown = Physics2D.Raycast(wallCheckDown.position, Vector2.right* Mathf.Sign(Input.GetAxisRaw("Horizontal")), wallDistance, groundLayer);


        Debug.DrawRay(wallCheckUp.position, wallDistance * Vector2.right * Mathf.Sign(Input.GetAxisRaw("Horizontal")), Color.cyan);
        Debug.DrawRay(wallCheckDown.position, wallDistance * Vector2.right * Mathf.Sign(Input.GetAxisRaw("Horizontal")), Color.cyan);
    }

}
