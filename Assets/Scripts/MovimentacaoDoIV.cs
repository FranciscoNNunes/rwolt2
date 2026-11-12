using UnityEngine;

public class MovimentacaoDoIV : MonoBehaviour
{
    [SerializeField] private Transform[] pontosDoCaminho;

    private int pontoAtual;

    [SerializeField] private float velocidadeDeMovimento;
    [SerializeField] private float amplitudeOscilacao = 0.5f;
    [SerializeField] private float frequenciaOscilacao = 5; 

    void Start()
    {
        pontoAtual = 0;
        if(pontosDoCaminho.Length > 0)
        {
        transform.position = pontosDoCaminho[pontoAtual].position;
        }
    }
    void Update()
    {
        if(pontosDoCaminho.Length == 0) return;
        flipHorizontal();
        MovimentarInimigo();
    }
    public void MovimentarInimigo()
    {
        Transform alvo = pontosDoCaminho[pontoAtual];

        Vector2 novaPosicao = Vector2.MoveTowards(transform.position, alvo.position, velocidadeDeMovimento * Time.deltaTime);

        float oscilacaoY = Mathf.Sin(Time.time * frequenciaOscilacao) * amplitudeOscilacao * Time.deltaTime;
        
        transform.position = novaPosicao;
        if(Vector2.Distance(transform.position, alvo.position) < 0.1f )
        {
            transform.position = alvo.position;
            pontoAtual++;

            if(pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0;
            }
        }
    }
    public void flipHorizontal()
    {
        Transform alvo = pontosDoCaminho[pontoAtual];

        if(alvo.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (alvo.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f,1f);
        }
    }
}
