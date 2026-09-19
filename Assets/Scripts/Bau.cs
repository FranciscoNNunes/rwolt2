using UnityEngine;

public class Bau : MonoBehaviour
{
    [SerializeField] GameObject guiaBau;
    public int chanceParaDropar;
    public GameObject itemParaDropar;
    private bool playerNoAlcance = false;
    private bool jaAberto = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        guiaBau.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerNoAlcance && Input.GetKeyDown(KeyCode.E) && !jaAberto)
        {
            AbrirBau();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("Player"))
        {
            guiaBau.SetActive(true);
            playerNoAlcance = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            guiaBau.SetActive(false);
            playerNoAlcance = false;
        }
    }
    public void AbrirBau()
    {
            jaAberto = true;
            int numeroAleatorio = Random.Range(0, 100);

            if (numeroAleatorio <= chanceParaDropar)
            {
                Instantiate(itemParaDropar, transform.position, Quaternion.identity);

            }
            Destroy(gameObject);
    }
}
