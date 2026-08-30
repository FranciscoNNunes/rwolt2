using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerLogic : MonoBehaviour
{
    public int vida;
    public int vidaMaxima;
    public GameObject escudo;
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundDist;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;

    [SerializeField] private int totaljump;

    [SerializeField] private Animator Anim;
    public bool temEscudo;
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;
    private int jumpLes;
    public Transform LocalDeAttack;
    public GameObject bullet;
    private bool isAttackCheck;
    private bool isgroundCheck;
    private bool canJump;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.4f;
    private float dashingCooldowm = 1f;
    [SerializeField] private TrailRenderer tr;

    private Rigidbody2D rb2d;
    private float inputDirection;

    private bool isDirectionRight = true;
    void Start()
    {
        Anim = GetComponent<Animator>();
        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        rb2d = GetComponent<Rigidbody2D>();
        jumpLes = totaljump;
        temEscudo = false;
        escudo.SetActive(false);
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Anim.SetTrigger("Attack");
        }

        GetInputMove();
        DirectionCheck();
        CanJump();
        MoveAnim();
        JumpAnim();
        HealthLogic();
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    public void AtivarEscudo()
    {
        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        escudo.SetActive(true);
        temEscudo = true;
    }
     public void GanharVida(int vidaParaReceber)
    {
        if(vida + vidaParaReceber <= vidaMaxima)
        {
            vida += vidaParaReceber;
        }
        else
        {
            vida = vidaMaxima;
        }
    }
        public void InstanciarNoUltimoFrame()
    {
        if(bullet != null && LocalDeAttack != null)
        {
        Instantiate(bullet, LocalDeAttack.position, LocalDeAttack.rotation);
        }
    }
    void HealthLogic()
    {


        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }


        for (int i = 0; i < coracao.Length; i++)
        {
            if (i < vida)
            {
                coracao[i].sprite = cheio;

            }
            else
            {
                coracao[i].sprite = vazio;
            }
            if (i < vidaMaxima)
            {

                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }
    public void TakeDamage(int danoParaReceber)
    {
        if (temEscudo == false)
        {
            vida -= danoParaReceber;
            if(vida <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            vida -= danoParaReceber;

            if (vida <= 0)
            {
                escudo.SetActive(false);
                temEscudo = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
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
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb2d.gravityScale;
        rb2d.gravityScale = 0f;
        rb2d.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new  WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb2d.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldowm);
        canDash = true;
    }
}
