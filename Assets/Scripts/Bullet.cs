using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletvelocity;

    public int danoParaDar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }
    private void MovimentarLaser()
    {
        transform.Translate(Vector2.right* bulletvelocity * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
                collision.gameObject.GetComponent<Enemy>().MachucarInimigo(danoParaDar);
                Destroy(gameObject);
        }
    }
}
