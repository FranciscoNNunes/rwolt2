using Unity.Cinemachine;
using UnityEngine;

public class Bau : MonoBehaviour
{
    public float vidaMaximaDoBau;
    public float vidaDoBau;
    public int chanceParaDropar;
    public GameObject itemParaDropar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaDoBau = vidaMaximaDoBau;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AbrirBau(int danoParaReceber)
    {
        vidaDoBau -= danoParaReceber;

        if (vidaDoBau <= 0)
        {
            int numeroAleatorio = Random.Range(0, 100);

            if (numeroAleatorio <= chanceParaDropar)
            {
                Instantiate(itemParaDropar, transform.position, Quaternion.Euler(0f, 0f, 0f));

            }
            Destroy(this.gameObject);
        }
    }
}
