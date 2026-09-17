using UnityEngine;

public class Guia : MonoBehaviour
{
    [SerializeField] private GameObject guia;

    void Start()
    {
        guia.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            guia.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            guia.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
