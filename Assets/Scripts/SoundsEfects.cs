using UnityEngine;

public class SoundsEfects : MonoBehaviour
{
    public static SoundsEfects instance;
    public AudioSource somDoPulo, somDeAttack, somDeConfirm, somDeUsoDeItem, somDeHit, somDeDash;
    void awake()
    {
        instance = this;
    }
    void Start()
    {

    }
    void Update()
    {
    }
}
