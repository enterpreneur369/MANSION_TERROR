using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject CanvasGO;

    public void GameOver()
    {
        Time.timeScale = 0f; // Pausa el juego
        CanvasGO.SetActive(true); // Activa el Canvas de Game Over
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die(); // Llama a la función Die del script Player
            }

            GameOver();
        }
    }
}
