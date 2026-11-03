using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerBossFinal : MonoBehaviour
{
    public Rigidbody2D origidbody2D;
    public GameObject bullet;
    public Transform localDoDisparoDaEsquerda;
    public Transform localDoDisparoDaDireita;
    public Transform localDoDisparoUnico;
    public float spaceshipVelocity;

    public bool temlaserDuplo;

    public bool temLaserTriplo;
    private Vector2 teclasApertadas;
    void Start()
    {
        temlaserDuplo = false;
        temLaserTriplo = false;
    }
    void Update()
    {
        MovimentarJogador();
        AtirarLaser();
    }
    private void MovimentarJogador()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        origidbody2D.linearVelocity = teclasApertadas.normalized * spaceshipVelocity;
    }
    private void AtirarLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (temlaserDuplo == false && temLaserTriplo == false)
            {
                Instantiate(bullet, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            }
            else if (temlaserDuplo == true && temLaserTriplo == false)
            {
                Instantiate(bullet, localDoDisparoDaEsquerda.position, localDoDisparoUnico.rotation);
                Instantiate(bullet, localDoDisparoDaDireita.position, localDoDisparoDaDireita.rotation);
            }
            else if (temlaserDuplo == false && temLaserTriplo == true)
            {
                Instantiate(bullet, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
                Instantiate(bullet, localDoDisparoDaDireita.position, localDoDisparoDaDireita.rotation);
                Instantiate(bullet, localDoDisparoDaEsquerda.position, localDoDisparoDaEsquerda.rotation);
            }
            else if (temlaserDuplo == true && temLaserTriplo == true)
            {

                Instantiate(bullet, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
                Instantiate(bullet, localDoDisparoDaDireita.position, localDoDisparoDaDireita.rotation);
                Instantiate(bullet, localDoDisparoDaEsquerda.position, localDoDisparoDaEsquerda.rotation);
            }
        }
    }
}
