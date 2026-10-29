using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public playerLogic player;

    public float vidaMaximaDoInimigo;

    public float vidaAtualDoInimigo;

    public int danoParaDar;

    public int chanceParaDropar;

    public GameObject itemParaDropar;

    void Start()
    {
        vidaAtualDoInimigo = vidaMaximaDoInimigo;

        if(player == null)
        {
            player = FindFirstObjectByType<playerLogic>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Colidiu com: " + collision.gameObject.name); // Vai mostrar no Console o nome de quem o inimigo encostou

    if (collision.gameObject.CompareTag("Player"))
    {
        playerLogic playerScript = collision.gameObject.GetComponent<playerLogic>();
        if(playerScript != null)
        {
            playerScript.TakeDamage(danoParaDar);
        }
    }
}
    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

        if(vidaAtualDoInimigo <= 0)
        {
            int numeroAleatorio = Random.Range(0, 100);

            if(numeroAleatorio <= chanceParaDropar && itemParaDropar != null)
            { 
                Instantiate(itemParaDropar,transform.position,Quaternion.identity);

            }
            Destroy(this.gameObject);
        }
    }
}
