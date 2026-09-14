using UnityEngine;
using UnityEngine.SceneManagement;

public class vacuo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
