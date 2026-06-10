using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // Arraste seu player para cá no Inspector
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10); // Distância da câmera

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
