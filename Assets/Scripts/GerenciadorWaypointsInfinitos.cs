using UnityEngine;
using System.Collections.Generic;

public class GerenciadorWaypointsInfinitos : MonoBehaviour
{
    public static GerenciadorWaypointsInfinitos Instance;

    public GameObject prefabWaypoint; 
    public float distanciaEntreWaypoints = 3f;
    public float velocidadeSubidaWaypoints = 2f;
    public int maxWaypointsNaTela = 10;
    public List<Transform> waypointsAtivos = new List<Transform>();
    private float proximaAlturaSpawn;

    private bool ladoDireito = true;

    public static bool pararGeracao = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        proximaAlturaSpawn = transform.position.y + distanciaEntreWaypoints;
        
        for (int i = 0; i < maxWaypointsNaTela; i++)
        {
            CriarNovoWaypointInicial();
        }
    }

    void Update()
    {
        if (pararGeracao) return;
        for (int i = waypointsAtivos.Count - 1; i >= 0; i--)
        {
            if (waypointsAtivos[i] != null)
            {
                waypointsAtivos[i].Translate(Vector3.up * velocidadeSubidaWaypoints * Time.deltaTime);
            }
            if (waypointsAtivos[i].position.y > 30f)
                {
                    Destroy(waypointsAtivos[i].gameObject);
                    waypointsAtivos.RemoveAt(i);
                    CriarNovoWaypointNaBase();
                }
            else
            {
                waypointsAtivos.RemoveAt(i);
            }
        }
    }

    void CriarNovoWaypointInicial()
    {
        float posX = ladoDireito ? 20f : -20f;

        Vector3 posicaoSpawn = new Vector3(posX, proximaAlturaSpawn, 0f);
        GameObject novoPonto = Instantiate(prefabWaypoint, posicaoSpawn, Quaternion.identity);
        
        waypointsAtivos.Add(novoPonto.transform);
        proximaAlturaSpawn += distanciaEntreWaypoints;
        ladoDireito = !ladoDireito;
    }
    void CriarNovoWaypointNaBase()
    {
        if (waypointsAtivos.Count > 0)
        {
        Transform waypointMaisBaixo = waypointsAtivos[0];
            foreach (var wp in waypointsAtivos)
            {
                if (wp != null && wp.position.y < waypointMaisBaixo.position.y)
                {
                    waypointMaisBaixo = wp;
                }
            }

            if (waypointMaisBaixo != null)
            {
                float posX = ladoDireito ? 20f : -20f;
                Vector3 posicaoSpawn = new Vector3(posX , waypointMaisBaixo.position.y - distanciaEntreWaypoints, 0f);
                GameObject novoPonto = Instantiate(prefabWaypoint, posicaoSpawn, Quaternion.identity);
                waypointsAtivos.Add(novoPonto.transform);
                ladoDireito = !ladoDireito;
            }
        }    
    }
}