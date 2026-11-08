using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPBossFinal : MonoBehaviour
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
        transform.Translate(Vector3.up * bulletvelocity * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MBoss"))
        {
                collision.gameObject.GetComponent<MBoss>().MachucarInimigo(danoParaDar);
                Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("bulletBoss"))
        {
                Destroy(this.gameObject);
        }
    }
}
