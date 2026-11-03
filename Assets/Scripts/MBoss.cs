using UnityEngine;

public class MBoss : MonoBehaviour
{
    public float speed = 3f;
    public float height = 3.5f;
    public float phaseOffset = 0f;
    public float startY;
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * speed + phaseOffset) * height;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
