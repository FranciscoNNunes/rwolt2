using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletVeloticy = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * bulletVeloticy * Time.deltaTime);
        if (transform.position.x < -7)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            heartSystem vidaPlayer = collision.GetComponent<heartSystem>();

            // Se o script de vida não estiver na raiz do Player, tenta buscar nos filhos ou pais
            if (vidaPlayer == null)
            {
                vidaPlayer = collision.GetComponentInChildren<heartSystem>();
            }

            Destroy(gameObject);
        }
    }
}
