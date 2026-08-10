using UnityEngine;

public class Triger : MonoBehaviour
{
    public heartSystem heart;
    private void Ontriggerenter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {

            heart.vida--;
        
        }
    }
}
