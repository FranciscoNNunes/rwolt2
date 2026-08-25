using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool itemDeEscudo;
    public bool itemDeVida;
    public bool itemDeTiroDuplo;
    public bool itemDeTiroTriplo;
    public int vidaParaDar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(itemDeEscudo == true)
            {
                collision.gameObject.GetComponent<playerLogic>().AtivarEscudo();
            }
            if (itemDeVida == true)
            {
                collision.gameObject.GetComponent<playerLogic>().GanharVida(vidaParaDar);
            }
        }
        Destroy(this.gameObject);
    }
}
