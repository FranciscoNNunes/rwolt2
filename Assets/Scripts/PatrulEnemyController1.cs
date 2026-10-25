using UnityEngine;

public class PatrulEnemyController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = -3;
    private bool isActivaded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if(isActivaded)
        {
            move();
        }
    }
    public void AtivarInimigo()
    {
        isActivaded = true;
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
