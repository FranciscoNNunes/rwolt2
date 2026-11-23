using UnityEngine;

public class EntradaDoCastelo : MonoBehaviour
{
    private Animator animCastle;
    private bool loboNaArea = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animCastle = GetComponent<Animator>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if(loboNaArea && Input.GetKeyDown(KeyCode.Z))
        {
            if(animCastle != null)
            {
                animCastle.SetTrigger("Aberto");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            loboNaArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            loboNaArea = false;
        }
    }
}
