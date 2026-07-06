using UnityEditor.Rendering;
using UnityEngine;

public class PackDeCura : MonoBehaviour
{
    public heartSystem heart;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            heart.vida++;
        }
    }
}
