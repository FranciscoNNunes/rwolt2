using UnityEngine;
using UnityEngine.Rendering;

public class ShootArea : MonoBehaviour
{
    public float raycastDistance = 10f;

    public GameObject bullet;
    public Transform firePoint;
    float coolDowm = 1f;
    float nextShot = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance);
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player") && Time.time > nextShot)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                nextShot = Time.time + coolDowm;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * raycastDistance);
    }
}
