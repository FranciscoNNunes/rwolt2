using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBoss : MonoBehaviour
{
    [SerializeField]private float bulletvelocity;
    public int danoParaDar;
    private float direction = -1f;

    [SerializeField] private Animator animator;
    [SerializeField] private int quantidadeDeLacaiosDiferentes = 3;

    private Vector3 escalaOriginal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3f);
        escalaOriginal = transform.localScale;

        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }

        EscolherLacaiosAleatorio();
    }
    public void SetDirection(float dir)
    {
        direction = dir;

        Vector3 escala = transform.localScale;
        escala.x = Mathf.Abs(escala.x) * direction;
        transform.localScale = escala;
        escalaOriginal = escala;
    }
    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }
    private void MovimentarLaser()
    {
        transform.Translate(Vector2.right * direction * bulletvelocity * Time.deltaTime, Space.World);
    }
    private void EscolherLacaiosAleatorio()
    {
        if(animator != null && quantidadeDeLacaiosDiferentes > 0)
        { 
            int lacaioSorteado = Random.Range(0, quantidadeDeLacaiosDiferentes);
        
            animator.SetInteger("TipoLacaio", lacaioSorteado);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vidaDoJogadorBossFinal player = collision.gameObject.GetComponent<vidaDoJogadorBossFinal>();
            if (player != null)
            {
                player.TakeDamage(danoParaDar);
            }
            Destroy(gameObject);
        }
    }
    private void OnColliderEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
        Destroy(gameObject);
        }
    }
}
