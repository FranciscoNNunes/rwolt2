using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicial : MonoBehaviour
{
    public void telaInicial()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}
