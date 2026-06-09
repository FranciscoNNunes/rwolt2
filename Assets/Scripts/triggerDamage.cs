using UnityEngine;

public class Triger : MonoBehaviour
{
    public heartSystem heart;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {

            heart.vida--;
        
        }
    }
}
