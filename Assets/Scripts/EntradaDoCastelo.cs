using UnityEngine;

public class EntradaDoCastelo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if(Input.GetKeyDown(KeyCode.KeypadEnter))
            {
               
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
