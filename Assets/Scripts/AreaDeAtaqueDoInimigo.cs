using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDeAtaqueDoInimigo : MonoBehaviour
{
    public int danoParaDar;
    private bool estaNaAreaDeAtaque;
    public float tempoDeVerificarAtaque = 1.0f;
    private Coroutine rotinaDeAtaque;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.CompareTag("Player"))

        estaNaAreaDeAtaque = true;

        rotinaDeAtaque = StartCoroutine(ExecutarAtaqueComAtraso(collision));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            estaNaAreaDeAtaque = false;
            if(rotinaDeAtaque != null)
        {
            StopCoroutine(rotinaDeAtaque);
        }
        }
    }
    void Update()
    {
    
    }
    private IEnumerator ExecutarAtaqueComAtraso(Collider2D playerCollider)
    {
            yield return new WaitForSeconds(tempoDeVerificarAtaque);

            if (estaNaAreaDeAtaque && playerCollider != null)
        {
            playerLogic player = playerCollider.GetComponent<playerLogic>();
            if (player != null)
            {
                player.TakeDamage(danoParaDar);
            }
        }
    }
}
