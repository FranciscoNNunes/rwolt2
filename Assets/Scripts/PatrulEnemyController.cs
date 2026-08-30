using UnityEngine;

public class PatrulEnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        speed *= -1;
        flip();
    }
    private void flip()
    {Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;}
    private void move()
    {
        rb.linearVelocity = new Vector2(speed,rb.linearVelocity.y);
    }
}
