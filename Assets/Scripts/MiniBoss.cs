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
    public GameObject itemParaDropar;
    void Start()
    {
        vidaAtualDoMBoss = vidaMaximaDoMBoss;
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
        estaNaAreaDeAtaque = true;

        rotinaDeAtaque = StartCoroutine(ExecutarAtaqueComAtraso(collision));
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
            }
        }
    }
    public void MachucarMBoss(int danoParaReceber)
    {
        vidaAtualDoMBoss-= danoParaReceber;

        if(vidaAtualDoMBoss <= 0)
        {
            Instantiate(itemParaDropar,transform.position,Quaternion.Euler(0f, 0f, 0f));
            Destroy(this.gameObject);
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
