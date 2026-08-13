using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class playerLogic : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundDist;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;

    [SerializeField] private int totaljump;

    [SerializeField] private Animator Anim;

    [SerializeField] private bool temEscudo;
    private int jumpLes;

    public GameObject bullet;

    private bool isgroundCheck;
    private bool canJump;

    private Rigidbody2D rb2d;
    private float inputDirection;

    private bool isDirectionRight = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpLes = totaljump;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

    }

    void Update()
    {
        GetInputMove();
        DirectionCheck();
        CanJump();
        MoveAnim();
        JumpAnim();
    }

    private void FixedUpdate()
    {
        MoveLogic();
        CheckArea();
    }
    void CanJump() 
    {
        if (isgroundCheck && rb2d.linearVelocity.y <= 0) 
        {
            jumpLes = totaljump;
        }

        if (jumpLes <= 0)
        {
            canJump = false;
        }

        else
        {
            canJump = true;
        }
    }
    void CheckArea() 
    {
        isgroundCheck = Physics2D.OverlapCircle(groundCheck.position, groundDist, groundLayer);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDist);
    }
    void DirectionCheck()
    {
        if (isDirectionRight && inputDirection < 0)
        {
            Flip();
        }
        else if(!isDirectionRight && inputDirection > 0)
        {
            Flip();
        }
    }
    void GetInputMove()
    {
        inputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    void MoveLogic()
    {
        rb2d.linearVelocity = new Vector2(inputDirection * moveSpeed,rb2d.linearVelocity.y);
    }
    void MoveAnim()
    {
        Anim.SetFloat("HorizontalAnim",rb2d.linearVelocity.x);
    }
    void Jump() 
    {
        if (canJump)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            jumpLes--;

        }   
    }
    void JumpAnim()
    {
        Anim.SetFloat("VerticalAnim", rb2d.linearVelocity.y);
        Anim.SetBool("GroundCheck", isgroundCheck);
    }
    void Flip() 
    {
        isDirectionRight = !isDirectionRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);

    }
}
