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
    public GameObject bulletBoss;
    public float direcaoTiro = 1f;
    
    public float velocidadeMovimento = 5f;
    private Transform alvoMovimento = null;
    public int indiceWaypointAtual = 0;

    void Start()
    {
        vidaAtualDoMBoss = vidaMaximaDoMBoss;
        
        DefinirProximoWaypoint();
    }

    void Update()
    {
        if (GerenciadorWaypointsInfinitos.Instance == null) return;
        if (alvoMovimento != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, alvoMovimento.position, velocidadeMovimento * Time.deltaTime);
            if (Vector2.Distance(transform.position, alvoMovimento.position) < 0.2f)
            {
                indiceWaypointAtual++;
                DefinirProximoWaypoint();
            }
        }
        else
        {
            DefinirProximoWaypoint();
        }
    }

    void DefinirProximoWaypoint()
    {
        var listaWaypoints = GerenciadorWaypointsInfinitos.Instance.waypointsAtivos;

        if (listaWaypoints != null && listaWaypoints.Count > 0)
        {
        
            if (indiceWaypointAtual >= listaWaypoints.Count)
            {
                indiceWaypointAtual = listaWaypoints.Count - 1;
            }

            if (listaWaypoints[indiceWaypointAtual] != null)
            {
                alvoMovimento = listaWaypoints[indiceWaypointAtual];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            estaNaAreaDeAtaque = true;
            if (rotinaDeAtaque == null)
            {
                rotinaDeAtaque = StartCoroutine(ExecutarAtaque());
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

    public void MachucarMBoss(int danoParaReceber)
    {
        vidaAtualDoMBoss -= danoParaReceber;

        if(vidaAtualDoMBoss <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator ExecutarAtaque()
    {
        yield return new WaitForSeconds(tempoDeVerificarAtaque);

        if (estaNaAreaDeAtaque)
        {
            GameObject novaBullet = Instantiate(bulletBoss, transform.position, Quaternion.identity);
            bulletBoss scriptBullet = novaBullet.GetComponent<bulletBoss>();
            if (scriptBullet != null)
            {
                scriptBullet.SetDirection(direcaoTiro);
            }
            
            rotinaDeAtaque = null;
        }
    }
}