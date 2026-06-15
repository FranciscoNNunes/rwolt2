using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPostX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;
    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y, player.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPostX =  _newRoom.position.x;
    }
}
