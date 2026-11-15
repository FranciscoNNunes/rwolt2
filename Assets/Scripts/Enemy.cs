using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public playerLogic player;

    public bool persegueJogador = false;
    public bool inimigoVoador = true;
    public float velocidadeDoInimigo = 3f;
    public float distanciaDaVisao = 5f;

    public float vidaMaximaDoInimigo;

    public float vidaAtualDoInimigo;

    public int danoParaDar;

    public int chanceParaDropar;

    public GameObject itemParaDropar;

    private Animator anim;
    void Start()
    {
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
        anim = GetComponent<Animator>();

        if(player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if(playerObj != null)
            {
            player = playerObj.GetComponent<playerLogic>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(persegueJogador && player != null)
        {
            float distancia = Vector2.Distance(transform.position, player.transform.position);

            if(distancia <= distanciaDaVisao)
            {
                SeguirJogador();
            }
        }
        
    }
    private void SeguirJogador()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidadeDoInimigo * Time.deltaTime);
        if(inimigoVoador)
        {
            transform.position += new Vector3(0, Mathf.Sin(Time.time * 5f) * 0.02f, 0);
        }
    }
   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        playerLogic playerScript = collision.gameObject.GetComponent<playerLogic>();
        if(playerScript != null)
        {
        if(anim != null) anim.SetTrigger("Attack");
            
        player.KBCount = player.KBTime;

        if(collision.transform.position.x <= transform.position.x)
        {
            player.isKnockRight = true;
        }
        else
        {
            player.isKnockRight = false;
        }
        playerScript.TakeDamage(danoParaDar);
        }
    }
}
    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

        if(vidaAtualDoInimigo <= 0)
        {
            if(anim != null) anim.SetTrigger("Death");

            enabled = false;
            Collider2D col = GetComponent<Collider2D>();
            if(col != null) col.enabled = false;

            int numeroAleatorio = Random.Range(0, 100);

            if(numeroAleatorio <= chanceParaDropar && itemParaDropar != null)
            { 
                Instantiate(itemParaDropar,transform.position,Quaternion.identity);

            }
            Destroy(this.gameObject);
        }
        else
        {
            if(anim != null) anim.SetTrigger("Hit");
        }
    }
}
