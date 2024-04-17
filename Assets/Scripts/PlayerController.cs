using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static bool playerCreated; // Indica si el jugador ya fue creado.
    public string nextPlaceName; // Nombre del próximo lugar a cargar.
    
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
    }

    // Update se llama una vez por frame.
    void Update()
    {
        walking = false; // Reinicia el estado de caminar.
        // Control de movimiento horizontal.
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
        {
            // Mueve el jugador horizontalmente basado en el input.
            _playerRigidBody.velocity = new Vector2(Input.GetAxisRaw(horizontal) * speed, 
                _playerRigidBody.velocity.y);
            walking = true; // Indica que el jugador está caminando.
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0); // Guarda la última dirección de movimiento horizontal.
        }
        
        // Control de movimiento vertical.
        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            // Mueve el jugador verticalmente basado en el input.
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, 
                Input.GetAxisRaw(vertical) * speed);
            walking = true; // Indica que el jugador está caminando.
            lastMovement = new Vector2(0, Input.GetAxisRaw(vertical)); // Guarda la última dirección de movimiento vertical.
        }

        // Si el jugador no está caminando, detiene su movimiento.
        if (!walking)
        {
            _playerRigidBody.velocity = Vector2.zero;
        }
        
        // Actualiza los parámetros de la animación basados en el movimiento.
        _animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        _animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
        _animator.SetBool(pWalking, walking);
        _animator.SetFloat(lastHorizontal, lastMovement.x);
        _animator.SetFloat(lastVertical, lastMovement.y);
    }
}
