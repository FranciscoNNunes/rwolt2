using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MiniBoss : MonoBehaviour
{
    public float vidaAtualDoMBoss;
    public float vidaMaximaDoMBoss;
    private bool estaNaAreaDeAtaque;
    public float tempoDeVerificarAtaque = 1.0f;
    private Coroutine rotinaDeAtaque;
    public int danoParaDar;
    public GameObject bulletBoss;
    public float direcaoTiro = 1f;
    public Transform[] pontosDeMovimento;
    public int indicePontoAtual = 0;
    public int indicePontoDestinoAposAtacar = 2; 
    public float velocidadeMovimento = 5f;
    private bool estaMovendo = false;
    private Transform alvoMovimento = null;
    void Start()
    {
        vidaAtualDoMBoss = vidaMaximaDoMBoss;

        if (pontosDeMovimento != null && pontosDeMovimento.Length > indicePontoAtual)
        {
            transform.position = pontosDeMovimento[indicePontoAtual].position;
        }
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.CompareTag("Player") && !estaMovendo)
        {
            estaNaAreaDeAtaque = true;
            if (rotinaDeAtaque == null)
            {
                rotinaDeAtaque = StartCoroutine(ExecutarAtaqueESubir());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            estaNaAreaDeAtaque = false;
            if(rotinaDeAtaque != null)
            {
                StopCoroutine(rotinaDeAtaque);
                rotinaDeAtaque = null;
            }
        }
    }
    public void MachucarMBoss(int danoParaReceber)
    {
        vidaAtualDoMBoss-= danoParaReceber;

        if(vidaAtualDoMBoss <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        if (estaMovendo && alvoMovimento != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, alvoMovimento.position, velocidadeMovimento * Time.deltaTime);

            if (Vector2.Distance(transform.position, alvoMovimento.position) < 0.1f)
            {
                estaMovendo = false;
            }
        }
    }
    private IEnumerator ExecutarAtaqueESubir()
    {
            yield return new WaitForSeconds(tempoDeVerificarAtaque);

        if (estaNaAreaDeAtaque)
        {
            GameObject novaBullet = Instantiate(bulletBoss, transform.position, Quaternion.identity);
            bulletBoss scriptBullet = novaBullet.GetComponent<bulletBoss>();
            if (scriptBullet != null)
            {
                scriptBullet.SetDirection(direcaoTiro);
            }
            if (pontosDeMovimento != null && pontosDeMovimento.Length > indicePontoDestinoAposAtacar)
            {
                alvoMovimento = pontosDeMovimento[indicePontoDestinoAposAtacar];
                estaMovendo = true;
            }
            
            rotinaDeAtaque = null;
        }
    }
}
