using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Removi a variável "public heartSystem heart" daqui de cima 
    // porque agora vamos pegar o script diretamente do Player que colidir.

    public float bulletVeloticy = 10f;

    void Start()
    {
        // Vazio
    }

    void Update()
    {
        // Move a bala para a esquerda
        transform.Translate(Vector2.left * bulletVeloticy * Time.deltaTime);

        // Destrói a bala se ela passar do limite da tela
        if (transform.position.x < -7)
        {
            Destroy(gameObject);
        }
    }

    // Usaremos APENAS o OnTriggerEnter2D. 
    // Certifique-se de que o Collider da Bala esteja marcado como "Is Trigger".
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se colidiu com a Layer do Player
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Busca o script heartSystem no objeto que colidiu
            heartSystem vidaPlayer = collision.GetComponent<heartSystem>();

            // Se não achar na raiz, busca nos filhos
            if (vidaPlayer == null)
            {
                vidaPlayer = collision.GetComponentInChildren<heartSystem>();
            }

            // Se encontrou o sistema de vida, tira 1 de vida
            if (vidaPlayer != null)
            {
                vidaPlayer.vida--;

                // Opcional: Se você tiver uma função de atualizar a UI dentro do heartSystem,
                // chame-a aqui, por exemplo: vidaPlayer.AtualizarInterface();
            }

            // Destrói a bala IMEDIATAMENTE após aplicar o dano
            Destroy(gameObject);
        }
    }
}
