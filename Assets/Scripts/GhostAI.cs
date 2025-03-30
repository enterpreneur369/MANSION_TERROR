using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena

/*
 *  Nombre comportamiento: IA del fantasma
 *  Caso de uso: Cuando el jugador tenga la llave un fantasma lo estará persiguiendo hasta que salga de la casa
 *  Datos de entrada: Llave en el inventario del jugador
 *  Datos de salida: Persecusión de fantasma al jugador
 */

public class GhostAI : MonoBehaviour
{
    public float chaseSpeed = 4f;  // Velocidad al perseguir
    public float patrolSpeed = 2f; // Velocidad en patrulla
    public Transform[] patrolPoints; // Puntos de patrulla
    public float detectionRange = 10f; // Rango de detección del jugador

    private int currentPatrolIndex = 0;
    private bool isChasing = false;
    private NavMeshAgent agent;
    private InventoryManager inventoryManager;
    private Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        inventoryManager = FindFirstObjectByType<InventoryManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (patrolPoints.Length > 0)
        {
            agent.destination = patrolPoints[currentPatrolIndex].position;
            agent.speed = patrolSpeed;
        }
    }

    void Update()
    {
        if (PlayerHasKey())
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    bool PlayerHasKey()
    {
        return inventoryManager != null && inventoryManager.HasItem(3); // 3 = Llave
    }

    void ChasePlayer()
    {
        if (!isChasing)
        {
            Debug.Log("👻 El fantasma ha detectado la llave y empieza a perseguir.");
            isChasing = true;
            agent.speed = chaseSpeed;
        }

        agent.destination = player.position;
    }

    void Patrol()
    {
        if (isChasing)
        {
            Debug.Log("👻 El jugador ya no tiene la llave. El fantasma deja de perseguir.");
            isChasing = false;
            agent.speed = patrolSpeed;
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.destination = patrolPoints[currentPatrolIndex].position;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Si toca al jugador, es Game Over
        {
            Debug.Log("💀 GAME OVER: El fantasma atrapó al jugador.");
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }
}
