using UnityEngine;
using UnityEngine.UI;

/*
 *  Nombre comportamiento: Caminar
 *  Caso de uso: El player requiere caminar para moverse dentro del videojuego a las diferentes escenas.
 *  Datos de entrada: teclado: A, S, W, D
 *  Datos de salida: movimiento hacia derecha, abajo, arriba y derecha 
 */

public class PlayerController : MonoBehaviour
{
    // Declaración de variables y constantes para controlar el movimiento y animación del jugador.
    public float speed = 4.0f; // Velocidad de movimiento del jugador.
    private bool walking = false; // Indica si el jugador está caminando.
    public Vector2 lastMovement = Vector2.zero; // Última dirección de movimiento del jugador.
    private const string horizontal = "Horizontal"; // Nombre del eje horizontal para el input.
    private const string vertical = "Vertical"; // Nombre del eje vertical para el input.
    private const string lastHorizontal = "LastHorizontal"; // Último valor horizontal para la animación.
    private const string lastVertical = "LastVertical"; // Último valor vertical para la animación.
    private const string pWalking = "Walking"; // Parámetro de caminar para la animación.
    private Rigidbody2D _playerRigidBody; // Componente de físicas para el movimiento.
    private Animator _animator; // Componente de animación.
    public Image pausePlayPanel;
    public static bool playerCreated; // Indica si el jugador ya fue creado.
    public string nextPlaceName; // Nombre del próximo lugar a cargar.
    public bool playerTalking; // Indica si el jugador está hablando con un NPC
    
    // Start se llama antes de la primera actualización del frame.
    void Start()
    {
        // Inicialización de componentes.
        _animator = GetComponent<Animator>(); // Obtiene el componente Animator del objeto.
        _playerRigidBody = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D del objeto.

        // Verifica si el jugador ya fue creado para evitar duplicados al cargar nuevas escenas.
        if (!playerCreated)
        {
            playerCreated = true; // Marca al jugador como creado.
            DontDestroyOnLoad(this.transform.gameObject); // Evita que el objeto se destruya al cargar una nueva escena.
        }
        else
        {
            Destroy(gameObject); // Destruye el objeto si el jugador ya fue creado anteriormente.
        }

        playerTalking = false;
    }

    // Update se llama una vez por frame.
   void Update()
    {
        if (playerTalking)
        {
            _playerRigidBody.linearVelocity = Vector2.zero;
        }
        walking = false; // Reinicia el estado de caminar.
        float horizontalInput = Input.GetAxisRaw(horizontal);
        float verticalInput = Input.GetAxisRaw(vertical);

        // Si el jugador se mueve en ambos ejes, damos prioridad a uno.
        if (Mathf.Abs(horizontalInput) > 0.5f && Mathf.Abs(verticalInput) > 0.5f)
        {
            // Priorizar movimiento horizontal, puedes cambiar esto si prefieres vertical.
            verticalInput = 0;
        }

        // Control de movimiento horizontal.
        if (Mathf.Abs(horizontalInput) > 0.5f)
        {
            _playerRigidBody.linearVelocity = new Vector2(horizontalInput * speed, _playerRigidBody.linearVelocity.y);
            walking = true;
            lastMovement = new Vector2(horizontalInput, 0); // Guarda la última dirección de movimiento horizontal.
        }

        // Control de movimiento vertical.
        if (Mathf.Abs(verticalInput) > 0.5f)
        {
            _playerRigidBody.linearVelocity = new Vector2(_playerRigidBody.linearVelocity.x, verticalInput * speed);
            walking = true;
            lastMovement = new Vector2(0, verticalInput); // Guarda la última dirección de movimiento vertical.
        }

        // Si el jugador no está caminando, detiene su movimiento.
        if (!walking)
        {
            _playerRigidBody.linearVelocity = Vector2.zero;
        }
        
        // Si el jugador pausa el juego con P
        if (Input.GetKey(KeyCode.P))
        {
            pausePlayPanel.gameObject.SetActive(true);
            pausePlayPanel.GetComponent<UIManager>().StopGame();
        }

        // Actualiza los parámetros de la animación basados en el movimiento.
        _animator.SetFloat(horizontal, horizontalInput);
        _animator.SetFloat(vertical, verticalInput);
        _animator.SetBool(pWalking, walking);
        _animator.SetFloat(lastHorizontal, lastMovement.x);
        _animator.SetFloat(lastVertical, lastMovement.y);
    }

}
