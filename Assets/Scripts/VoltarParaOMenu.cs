using UnityEngine.SceneManagement;
using UnityEngine;

public class VoltarParaOMenu : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
