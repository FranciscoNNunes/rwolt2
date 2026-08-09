using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private string nomeproximafase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Irproximafase();
    }
    private void Irproximafase()
    {
        SceneManager.LoadScene(this.nomeproximafase);
    }

}
