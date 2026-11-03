using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vidaDoJogadorBossFinal : MonoBehaviour
{
    public Slider barraDeVidaDoJogador;
    public GameObject escudo;
    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;
    public bool temEscudo;
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        barraDeVidaDoJogador.maxValue = vidaMaximaDoJogador;
        barraDeVidaDoJogador.value = vidaAtualDoJogador;
        escudo.SetActive(false);
        temEscudo = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AtivarEscudo()
    {
        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        escudo.SetActive(true);
        temEscudo = true;
    }
    public void GanharVida(int vidaParaReceber)
    {
        if(vidaAtualDoJogador + vidaParaReceber <= vidaMaximaDoJogador)
        {
            vidaAtualDoJogador += vidaParaReceber;
        }
        else
        {
            vidaAtualDoJogador = vidaMaximaDoJogador;
        }
        barraDeVidaDoJogador.value = vidaAtualDoJogador;
    }
    public void TakeDamage(int danoParaReceber)
    {
        if (temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;
            barraDeVidaDoJogador.value = vidaAtualDoJogador;
            if(vidaAtualDoJogador <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            vidaAtualDoEscudo -= danoParaReceber;

            if (vidaAtualDoEscudo <= 0)
            {
                escudo.SetActive(false);
                temEscudo = false;
            }
        }
    }
}
