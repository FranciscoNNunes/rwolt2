using UnityEngine.SceneManagement;
using UnityEngine;

public class BossesManager : MonoBehaviour
{
    public static BossesManager Instance;

    public MiniBoss boss1;
    public MiniBoss boss2;

    public string nomeCenaCutscene = "NomeDaCutscene";

    void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool boss1Morto = (boss1 == null);
        bool boss2Morto = (boss2 == null);

        if(boss1Morto && boss2Morto)
        {
            DispararCutscene();
        }
    }
    void DispararCutscene()
    {
        GerenciadorWaypointsInfinitos.pararGeracao = true;

        SceneManager.LoadScene(nomeCenaCutscene);
    }
}
