using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;//objeto que ser� clonado
    public float spawnFrequency;//Frequ�ncia de tempo
    private float _timer;//contador de tempo

    public Transform left;//Limite esquerda do spawn
    public Transform right;// limite direite do spawn

    void Update()
    {
        _timer += Time.deltaTime;//soma de tempo entre frames
        if (_timer >= spawnFrequency)
        {

            //ist�ncia o prefab na cena
            GameObject enemy = Instantiate(prefab, transform);
            //Gera um valor aleat�rio e armazena em uma vari�vel
            float newx = Random.Range(left.position.x, right.position.x);
            //Atribui a nova posi��o para o inmigo
            enemy.transform.position = new Vector2(newx, transform.position.y);
            //Zerar o tempo
            _timer = 0;
        }
    }
}
