using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenuMenagger : MonoBehaviour
{
    [SerializeField] private string Creditos;
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField]private GameObject painelMainMenu;
    [SerializeField]private GameObject painelOptions;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
    public void Credits()
    {
        SceneManager.LoadScene(Creditos);
    }
    public void BTN_Quit()
    {
        Application.Quit();
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#endif

    }
}
