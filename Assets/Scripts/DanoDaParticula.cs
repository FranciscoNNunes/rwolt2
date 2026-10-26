using UnityEngine;

public class DanoDaParticula : MonoBehaviour
{
    public int dano;
    private void OnParticleCollision(GameObject other)
    {
        var vida = other.GetComponent<playerLogic>();
        if (vida != null)
        {
            vida.TakeDamage(dano);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
