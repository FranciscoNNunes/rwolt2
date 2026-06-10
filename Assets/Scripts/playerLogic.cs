using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundDist;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;

    [SerializeField] private int totaljump;

    private int jumpLes;

    private bool isgroundCheck;
    private bool canJump;

    private Rigidbody2D rb2d;
    private float inputDirection;

    private bool isDirectionRight = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpLes = totaljump;
    }

    void Update()
    {
        GetInputMove();
        DirectionCheck();
        CanJump();
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
    void Jump() 
    {
        if (canJump)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            jumpLes--;

        }
       
    
    }
    void Flip() 
    {
        isDirectionRight = !isDirectionRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);

    }
}
