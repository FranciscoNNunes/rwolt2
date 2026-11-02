using UnityEngine;

public class MovimentacaoDoIV : MonoBehaviour
{
    [SerializeField] private Transform[] pontosDoCaminho;

    private int pontoAtual;

    [SerializeField]    private float velocidadeDeMovimento;

    private float ultimaPosicaoX;

    void Start()
    {
        pontoAtual = 0;
        transform.position = pontosDoCaminho[pontoAtual].position;
    }
    void Update()
    {
        flipHorizontal();
        MovimentarInimigo();
    }
    private void MovimentarInimigo()
    {
        transform.position = Vector2.MoveTowards(transform.position, pontosDoCaminho[pontoAtual].position, velocidadeDeMovimento * Time.deltaTime);
        if(transform.position == pontosDoCaminho[pontoAtual].position)
        {
            pontoAtual += 1;

            ultimaPosicaoX = transform.localPosition.x;  

            if(pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0;
            }
        }
    }
    private void flipHorizontal()
    {
        if(transform.localPosition.x < ultimaPosicaoX)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (transform.localPosition.x > ultimaPosicaoX)
        {
            transform.localScale = new Vector3(-1f, 1f,1f);
        }
    }
}
