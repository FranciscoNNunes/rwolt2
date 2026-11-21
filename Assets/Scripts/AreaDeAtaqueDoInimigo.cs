using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDeAtaqueDoInimigo : MonoBehaviour
{
    public int danoParaDar;
    private bool estaNaAreaDeAtaque;
    public float tempoDeVerificarAtaque = 1.0f;
    private Coroutine rotinaDeAtaque;

    [SerializeField] private Animator Anim;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            estaNaAreaDeAtaque = true;

            if(rotinaDeAtaque == null)
            {

            rotinaDeAtaque = StartCoroutine(ExecutarAtaqueComAtraso(collision));
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
    void Update()
    {
    
    }
    private IEnumerator ExecutarAtaqueComAtraso(Collider2D playerCollider)
    {       
        while(estaNaAreaDeAtaque)
        {
            if(Anim != null)
            {
                Anim.SetTrigger("Attack");
            }
            yield return new WaitForSeconds(0.6f);

            if (estaNaAreaDeAtaque && playerCollider != null)
            {
                playerLogic player = playerCollider.GetComponent<playerLogic>();
                if (player != null)
                {
                player.TakeDamage(danoParaDar);
                }
            }

            float tempoRestante = tempoDeVerificarAtaque - 0.6f;
            if(tempoRestante > 0)
            {
                yield return new WaitForSeconds(tempoRestante);
            }
        }
        rotinaDeAtaque = null;
    }
}
