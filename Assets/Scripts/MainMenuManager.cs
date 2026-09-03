using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenuMenagger : MonoBehaviour
{
    [SerializeField] private string credits;
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField]private GameObject painelMainMenu;
    [SerializeField]private GameObject painelOptions;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
    public void Creditos()
    {
        SceneManager.LoadScene(credits);
    }
    public void BTN_Quit()
    {
        Application.Quit();
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#endif

    }
}
