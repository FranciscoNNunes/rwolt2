using UnityEngine;

public class triggerDamage : MonoBehaviour
{
    public heartSystem heart;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) 
        {

            heart.vida--;
        
        }
    }
}
