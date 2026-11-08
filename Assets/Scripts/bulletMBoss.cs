 using UnityEngine;

public class bulletMBoss : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public bool shootAtPlayer = false;
    public int bulletCount = 3;
    public float spreadAngle = 30f;
    public float fireRate = 1.5f;

    public bool randomAngle = true;
    public float minRandomAngle = 0f;
    public float maxRandomAngle = 360f;

    private float fireTimer;
    private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }
    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

            float baseAngle = 0f;

        if(randomAngle)
        {

            baseAngle = Random.Range(minRandomAngle, maxRandomAngle);
        }
        else if (shootAtPlayer && playerTransform != null)
        {
                Vector2 direction = (playerTransform.position - firePoint.position).normalized;
                baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
        else
        {
                baseAngle = firePoint.eulerAngles.z - 90f; 
        }
        if (bulletCount <= 1)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, baseAngle));
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            float halfAngle = spreadAngle / 2f;
            float angleStep = spreadAngle / (bulletCount - 1);

            for (int i = 0; i < bulletCount; i++)
            {
                float currentAngle = (baseAngle - halfAngle) + (angleStep * i);
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));
                
                Instantiate(bulletPrefab, firePoint.position, rotation);
            }
        }
    }
}

