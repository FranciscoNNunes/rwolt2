using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, speed);
    }
    void Update()
    {

    }
    private void OnBecameInvisible()//Aciona quando o objeto com arte sai da c�mera
    {
        Destroy(gameObject);
    }
    //Evento acionado quando este objeto bate em outro. Esse ou o outro
    //deve ser isTrigger
    private void OnTriggerEnter2D(Collider2D collision)//Esse collision � o objeto que bateu
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);//Esse destroi o inimigo
            Destroy(gameObject);//Esse destroi a pr�pria bala
        }

    }
}
