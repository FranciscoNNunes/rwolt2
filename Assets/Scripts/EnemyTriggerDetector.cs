using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerDetector : MonoBehaviour
{
    private float speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PatrulEnemyController1 enemyController;
    void Start()
    {
        if(enemyController == null)
        {

            enemyController = GetComponentInParent<PatrulEnemyController1>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(enemyController != null)
            {
                enemyController.AtivarInimigo();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            speed *= -1;
            flip();
        }
    }
    private void flip()
    {Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;}
    // Update is called once per frame
    void Update()
    {
        
    }
}
