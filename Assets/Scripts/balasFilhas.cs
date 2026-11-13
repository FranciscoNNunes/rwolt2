using UnityEngine;

public class balasFilhas : MonoBehaviour
{
    public float speed = 8f;
    public int damageToPlayer = 1;
    public float lifeTime = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<vidaDoJogadorBossFinal>().TakeDamage(damageToPlayer);
            Destroy(gameObject);
        }
        if(collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
