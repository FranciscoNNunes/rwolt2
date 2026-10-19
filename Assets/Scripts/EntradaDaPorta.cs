using UnityEngine.SceneManagement;
using UnityEngine;

public class EntradaDaPorta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           SceneManager.LoadScene("CasaDoBellator");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
