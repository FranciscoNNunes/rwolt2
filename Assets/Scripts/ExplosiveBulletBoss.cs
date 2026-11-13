using UnityEngine;

public class ExplosiveBulletBoss : MonoBehaviour
{
    public GameObject childBulletPrefab;
    public int splitCount = 4;
    public float spreadAngle = 360f;
    public string playerAttackTag = "PlayerBullet";
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
        if(collision.CompareTag(playerAttackTag))
        {
            Split();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    void Split()
    {
        if(childBulletPrefab == null) return;

        float angleStep = spreadAngle / splitCount;
        float startAngle = transform.eulerAngles.z - (spreadAngle / 2f);

        for(int i = 0; i < splitCount; i++)
        {
            float currentAngle = startAngle + (angleStep * i);
            Quaternion rotation = Quaternion.Euler(0,0, currentAngle);

            Instantiate(childBulletPrefab, transform.position, rotation);
        }
    }
}
