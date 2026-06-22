using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPerseguidor : MonoBehaviour
{
    private Transform posicaoDoJogador;

    public float velocidadeDoInimigo;
    void Start()
    {
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        SeguirJogador();
    }
    private void SeguirJogador()
    {
        if (posicaoDoJogador.gameObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeDoInimigo * Time.deltaTime);
        }
    }
}
