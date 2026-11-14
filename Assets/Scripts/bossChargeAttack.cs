using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossChargeAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float detectionRange = 8f;
    public float chargeTime = 1.2f;
    public float highSpeed = 25f;
    public float attackCooldown = 3f;

    public float minAngle = -45f;
    public float maxAngle = 45f;

    private Transform playerTransform;
    private bool isAttacking = false;
    private bool canAttack = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerTransform = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerTransform == null || isAttacking) return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if(distanceToPlayer <= detectionRange)
        {
            StartCoroutine(ChargeAndShootRoutine());
        }
    }
    public void AtivarFaseDoisAtaque()
    {
        canAttack = true;
    }
    IEnumerator ChargeAndShootRoutine()
    {
        isAttacking = true;
        List<GameObject> chargedBullets = new List<GameObject>();
        float spreadAngle = 30f;

        Vector2 direction = (playerTransform.position - firePoint.position).normalized;
        float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        baseAngle = Mathf.Clamp(baseAngle, minAngle, maxAngle);

        for(int i = 0; i < 3; i++)
        {
            float halfAngle = spreadAngle / 2f;
            float angleStep = spreadAngle / 2f;
            float currentAngle = (baseAngle - halfAngle) + (angleStep * i);
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation, firePoint);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null) rb.simulated = false;

            chargedBullets.Add(bullet);
        }

        float timer = 0f;
        while (timer < chargeTime)
        {
            timer += Time.deltaTime;

            foreach (GameObject b in chargedBullets)
            {
                if (b != null)
                {
                    Vector3 randomOffset = (Vector3)Random.insideUnitCircle * 0.05f;
                    b.transform.localPosition = Vector3.zero + randomOffset;
                }
            }

            yield return null;
        }

        foreach (GameObject bullet in chargedBullets)
        {
            if(bullet != null)
            {
                bullet.transform.SetParent(null);

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if(rb != null)
                {
                    rb.simulated = true;

                    rb.linearVelocity = bullet.transform.right * highSpeed;
                }
            }
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
