using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float bulletvelocity;
    public int danoParaDar;
    private float direction = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    public void SetDirection(float dir)
    {
        direction = dir;

        Vector3 escala = transform.localScale;
        escala.x = Mathf.Abs(escala.x) * direction;
        transform.localScale = escala;
    }
    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }
    private void MovimentarLaser()
    {
        transform.Translate(Vector2.right * direction * bulletvelocity * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
                collision.gameObject.GetComponent<Enemy>().MachucarInimigo(danoParaDar);
                Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
