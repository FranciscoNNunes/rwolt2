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

    private playerLogic player;
    void Start()
    {
        centerPoint = new Vector2(transform.position.x, transform.position.y);
        vidaAtualDoInimigo = vidaMaximaDoInimigo;

        if(player == null)
        {
            player = FindFirstObjectByType<playerLogic>();
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
        if(player != null)
        {   
            player.KBCount = player.KBTime;
            player.isKnockRight = (collision.transform.position.x > transform.position.x);
            player.TakeDamage(danoParaDar);
        }
    }
    }
    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

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
}
