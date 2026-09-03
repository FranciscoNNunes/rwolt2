using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletvelocity;
    public int danoParaDar;
    private float direction = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void SetDirection(float dir)
    {
        direction = dir;
    }
    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }
    private void MovimentarLaser()
    {
        transform.Translate(Vector2.right * direction * bulletvelocity * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
                collision.gameObject.GetComponent<Enemy>().MachucarInimigo(danoParaDar);
                Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Bau"))
        {
                collision.gameObject.GetComponent<Bau>().AbrirBau(danoParaDar);
                Destroy(gameObject);
        }
    }
}
