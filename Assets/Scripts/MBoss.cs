using UnityEngine;

public class MBoss : MonoBehaviour
{
    public float speed = 3f;
    public float height = 3.5f;
    public float phaseOffset = 0f;

    private Vector2 centerPoint;
    
    public float vidaMaximaDoInimigo;

    public float vidaAtualDoInimigo;

    public int danoParaDar;

    public int chanceParaDropar;

    public GameObject itemParaDropar;

    private vidaDoJogadorBossFinal playerVida;

    private bool isPhaseTwo = false;
    private bool isPhaseThree = false;

    public bulletMBoss atiradorFaseUm;
    public bossChargeAttack atiradorFaseDois;
    public bossUltimateAttack ataqueSupremo; 
    void Start()
    {
        centerPoint = new Vector2(transform.position.x, transform.position.y);
        vidaAtualDoInimigo = vidaMaximaDoInimigo;

        if(playerVida == null)
        {
            playerVida = FindFirstObjectByType<vidaDoJogadorBossFinal>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Time.time * speed + phaseOffset;
        float newY = centerPoint.y + Mathf.Sin(angle) * height;

        transform.position = new Vector3(centerPoint.x, newY, transform.position.z);
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Player"))
    {
        if(playerVida != null)
        {   
            playerVida.TakeDamage(danoParaDar);
        }
    }
    }
    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

        if(!isPhaseTwo && vidaAtualDoInimigo <= vidaMaximaDoInimigo / 2f)
        {
            entrarNaFaseDois();
        }
        if(!isPhaseThree && vidaAtualDoInimigo <= vidaMaximaDoInimigo * 0.2f)
        {
            entrarNaFaseTres();
        }
        if(vidaAtualDoInimigo <= 0)
        {
            int numeroAleatorio = Random.Range(0, 100);

            if(numeroAleatorio <= chanceParaDropar && itemParaDropar != null)
            { 
                Instantiate(itemParaDropar,transform.position,Quaternion.identity);

            }
            Destroy(this.gameObject);
        }
    }
    void entrarNaFaseDois()
    {
        isPhaseTwo = true;

        speed *= 1.3f;

        if(atiradorFaseUm != null)
        {
            atiradorFaseUm.enabled = false;
        }
        if(atiradorFaseDois != null)
        {
            atiradorFaseDois.AtivarFaseDoisAtaque();
        }
    }
    void entrarNaFaseTres()
    {
        isPhaseThree = true;
        speed *= 1.2f;

        if(ataqueSupremo != null)
        {
            ataqueSupremo.AtivarFaseTres();
        }
    }
}
