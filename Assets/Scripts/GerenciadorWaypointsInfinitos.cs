using UnityEngine;
using System.Collections.Generic;

public class GerenciadorWaypointsInfinitos : MonoBehaviour
{
    public static GerenciadorWaypointsInfinitos Instance;

    public GameObject prefabWaypoint; 
    public float distanciaYEntreWaypoints = 13f;
    public float velocidadeSubidaWaypoints = 2f;
    public int maxWaypointsNaTela = 10;
    public List<Transform> waypointsAtivos = new List<Transform>();

    private Vector3 UltimaPosicaoGerada;
    public static bool pararGeracao = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UltimaPosicaoGerada = new Vector3(20f, -5f, 0f);
        
        for (int i = 0; i < maxWaypointsNaTela; i++)
        {
            CriarWaypointInicial();
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
                    CriarWaypointNaBase();
                }
            else
            {
                waypointsAtivos.RemoveAt(i);
            }
        }
    }

    void CriarWaypointInicial()
    {
        GameObject novoPonto = Instantiate(prefabWaypoint, UltimaPosicaoGerada, Quaternion.identity);
        waypointsAtivos.Add(novoPonto.transform);

        float novoX = -UltimaPosicaoGerada.x;
        float novoY = UltimaPosicaoGerada.y + distanciaYEntreWaypoints;
        UltimaPosicaoGerada = new Vector3(novoX, novoY, 0f);
    }
    void CriarWaypointNaBase()
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
                float novoX = -waypointMaisBaixo.position.x;
                float novoY = waypointMaisBaixo.position.y + distanciaYEntreWaypoints;
                Vector3 posicaoSpawn = new Vector3(novoX, novoY, 0f);
                GameObject novoPonto = Instantiate(prefabWaypoint, posicaoSpawn, Quaternion.identity);
                waypointsAtivos.Add(novoPonto.transform);
            }
        }    
    }
}