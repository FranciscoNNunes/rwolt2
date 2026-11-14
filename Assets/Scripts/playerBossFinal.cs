using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerBossFinal : MonoBehaviour
{
    public Rigidbody2D origidbody2D;
    public GameObject bullet;
    public Transform localDoDisparoUnico;
    public float spaceshipVelocity;
    private Vector2 teclasApertadas;
    void Start()
    {

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
            {
                Instantiate(bullet, localDoDisparoUnico.position, localDoDisparoUnico.rotation);
            }
        }
    }
}
