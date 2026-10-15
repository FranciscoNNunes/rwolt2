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
        proximaAlturaSpawn = transform.position.y;
        
        for (int i = 0; i < maxWaypointsNaTela; i++)
        {
            CriarNovoWaypoint();
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
            else
            {
                waypointsAtivos.RemoveAt(i);
            }
        }
    }

    void CriarNovoWaypoint()
    {
        Vector3 posicaoSpawn = new Vector3(transform.position.x + Random.Range(-3f, 3f), proximaAlturaSpawn, 0f);
        GameObject novoPonto = Instantiate(prefabWaypoint, posicaoSpawn, Quaternion.identity);
        
        waypointsAtivos.Add(novoPonto.transform);
        proximaAlturaSpawn += distanciaEntreWaypoints;
    }
}