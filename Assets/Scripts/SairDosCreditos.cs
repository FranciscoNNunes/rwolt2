using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SairDosCreidtos : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }
}

