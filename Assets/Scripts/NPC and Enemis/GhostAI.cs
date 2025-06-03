using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostAI : MonoBehaviour
{
    public float speed = 3f;
    private Transform player;
    private bool isActive = false;

    void Start()
    {
        FindPlayer(); // Buscar al jugador al cargar la escena
    }

    void Update()
    {
        if (isActive && player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void ActivateGhost()
    {
        isActive = true;
        gameObject.SetActive(true); // Aparece el fantasma
        FindPlayer(); // Intentar encontrar al jugador en caso de que aún no se haya detectado
    }

    public void DeactivateGhost()
    {
        isActive = false;
        gameObject.SetActive(false); // Desaparece el fantasma
    }

    private void FindPlayer()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player"); // Busca al jugador por su etiqueta
        if (Player != null)
        {
            player = Player.transform;    
        }
    }
}