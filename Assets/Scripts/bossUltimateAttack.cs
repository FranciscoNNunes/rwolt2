using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossUltimateAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float warningTime = 2.0f;
    public float bulletSpeed = 8f;
    public float attackCooldown = 5f;
    private bool isUltActive = false;
    private bool canUseUlt = false;
    private SpriteRenderer bossSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!canUseUlt || isUltActive) return;

        StartCoroutine(UltimateAttackRoutine());
    }
    public void AtivarFaseTres()
    {
        canUseUlt = true;
    }
    IEnumerator UltimateAttackRoutine()
    {
        isUltActive = true;

        float timer = 0f;
        bool isRed = false;
        while (timer < warningTime)
        {
            timer += 0.2f;
            if (bossSprite != null)
            {
                bossSprite.color = isRed ? Color.white : Color.red;
            }
            isRed = !isRed;
            yield return new WaitForSeconds(0.2f);
        }

        if(bossSprite != null) bossSprite.color = Color.white;

        int totalBullets = 9;
        int gapIndex = Random.Range(2, 7);

        float startYOffset = -3.5f;
        float spacing = 0.9f;

        for (int i = 0; i < totalBullets; i++)
        {
            if (i == gapIndex || i == gapIndex + 1) continue;

            Vector3 spawnPosition = new Vector3(firePoint.position.x, firePoint.position.y + startYOffset + (i * spacing), 0f);
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = true;

                rb.linearVelocity = new Vector2(-bulletSpeed, 0f);
            }
        }

        yield return new WaitForSeconds(attackCooldown);
        isUltActive = false;
    }
}
