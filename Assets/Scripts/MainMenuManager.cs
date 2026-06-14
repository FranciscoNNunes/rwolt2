using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenuMenagger : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField]private GameObject painelMainMenu;
    [SerializeField]private GameObject painelOptions;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
    public void AbrirOptions()
    {
        painelMainMenu.SetActive(false);
        painelOptions.SetActive(true);
    }
    public void FecharOptions()
    {
        painelOptions.SetActive(false);
        painelMainMenu.SetActive(true);
    }
    public void SairDoJogo()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
