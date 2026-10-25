using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.Hierarchy;
using System.Collections.Generic;


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

    public float KBForce;
    public float KBCount;
    public float KBTime;

    public bool isKnockRight;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip somPulo;
    [SerializeField] private AudioClip somDash;
    [SerializeField] private AudioClip somAtaque;
    [SerializeField] private AudioClip somHit;
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
            TocarSom(somAtaque);
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
            Anim.SetTrigger("Dash");
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
        GameObject Bullet = Instantiate(bullet, LocalDeAttack.position, LocalDeAttack.rotation);

        float direcaoAtual = transform.localScale.x > 0 ? 1f :-1f;
        Bullet.GetComponent<Bullet>().SetDirection(direcaoAtual);
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
        if (vida <= 0) return;

        TocarSom(somHit);

        if (!temEscudo)
        {
            vida -= danoParaReceber;
            if (vida <= 0)
            {
                vida = 0;
                StartCoroutine(Morrer());
            }
        }
        else
        {
            vidaAtualDoEscudo -= danoParaReceber;
            if (vidaAtualDoEscudo <= 0)
            {
                if (escudo != null) escudo.SetActive(false);
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
        knockLogic();
        CheckArea();
    }

    void knockLogic()
    {
        if(KBCount < 0)
        {
            MoveLogic();
        }
        else
        {
            if(isKnockRight == true)
            {
                rb2d.linearVelocity = new Vector2(-KBForce, KBForce);
            }
            if(isKnockRight == false)
            {

                rb2d.linearVelocity = new Vector2(KBForce, KBForce);
            }
        }
        KBCount -= Time.deltaTime;
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
        Anim.SetFloat("HorizontalAnim", Mathf.Abs(inputDirection));
    }
    void Jump() 
    {
        if (canJump)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            jumpLes--;
            TocarSom(somPulo);
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
        Vector3 escala = transform.localScale;
        escala.x*= -1;
        transform.localScale = escala;

    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        TocarSom(somDash);
        
        float originalGravity = rb2d.gravityScale;
        rb2d.gravityScale = 0f;
        rb2d.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        
        if (tr != null) tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        if (tr != null) tr.emitting = false;
        
        rb2d.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldowm);
        canDash = true;
    }

    private IEnumerator Morrer()
    {

        Anim.SetTrigger("Death");

        rb2d.linearVelocity = Vector2.zero;
        rb2d.simulated = false;

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null) collider.enabled = false;

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.enabled = false;
    }
    private void TocarSom(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
