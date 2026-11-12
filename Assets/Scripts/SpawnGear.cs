using UnityEngine;

public class SpawnGear : MonoBehaviour
{
    public GameObject prefab;
    public float spawnFrequency;
    private float _timer;
    public Transform left;
    public Transform right;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnFrequency)
        {

            GameObject gear = Instantiate(prefab, transform);

            float newx = Random.Range(left.position.x, right.position.x);

            gear.transform.position = new Vector2(newx, transform.position.y);
            _timer = 0;
        }
    }
}
