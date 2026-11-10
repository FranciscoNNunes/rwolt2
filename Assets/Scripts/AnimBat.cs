using UnityEngine;

public class Anim_BAt : MonoBehaviour
{
    [SerializeField] private Animator Anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Anim.SetTrigger("Attack");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
