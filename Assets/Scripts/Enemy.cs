using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float vidaMaximaDoInimigo;

    public float vidaAtualDoInimigo;

    public int danoParaDar;

    public int chanceParaDropar;

    public GameObject itemParaDropar;

    void Start()
    {
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerLogic>().TakeDamage(danoParaDar);
            Destroy(this.gameObject);
        }
    }
    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

        if(vidaAtualDoInimigo <= 0)
        {
            int numeroAleatorio = Random.Range(0, 100);

            if(numeroAleatorio <= chanceParaDropar)
            { 
                Instantiate(itemParaDropar,transform.position,Quaternion.Euler(0f, 0f, 0f));

            }
            Destroy(this.gameObject);
        }
    }
}
