using UnityEngine;

public class EngragemQueCai : MonoBehaviour
{
    public int dano;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<vidaDoJogadorBossFinal>().TakeDamage(dano);
            Destroy(this.gameObject);
        }
    }
}
