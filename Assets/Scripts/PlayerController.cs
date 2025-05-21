using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    private Rigidbody2D _playerRigidBody;
    private Animator _animator;
    public Image pausePlayPanel;
    public static bool playerCreated;
    public bool playerTalking;
    public Vector2 lastMovement = Vector2.zero; // Se hace público para ser accesible.
    public string nextPlaceName; // Nombre del próximo lugar a cargar.

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string pWalking = "Walking";

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody2D>();

        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerTalking = false;
    }

    void Update()
    {
        // Verifica si el jugador está hablando, detiene el movimiento.
        if (playerTalking)
        {
            _playerRigidBody.linearVelocity = Vector2.zero;
            return;
        }

        float horizontalInput = Input.GetAxisRaw(horizontal);
        float verticalInput = Mathf.Abs(horizontalInput) > 0.5f ? 0 : Input.GetAxisRaw(vertical);

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed;
        bool walking = movement != Vector2.zero;

        _playerRigidBody.linearVelocity = walking ? movement : Vector2.zero;

        if (walking)
            lastMovement = movement.normalized;

        if (Input.GetKeyDown(KeyCode.P))
        {
            pausePlayPanel.gameObject.SetActive(true);
            pausePlayPanel.GetComponent<UIManager>().StopGame();
        }
        // se utilizan las teclas f y g  para realizar las acciones del inventario dar y usar
        if (Input.GetKeyDown(KeyCode.G))
        {
            FindFirstObjectByType<ActionsManager>().GiveAction();
        }       
        if (Input.GetKeyDown(KeyCode.F))
        {
            FindFirstObjectByType<ActionsManager>().UseAction();
        }

        // Actualiza los parámetros del Animator
        _animator.SetFloat(horizontal, horizontalInput);
        _animator.SetFloat(vertical, verticalInput);
        _animator.SetBool(pWalking, walking);
        _animator.SetFloat(lastHorizontal, lastMovement.x);
        _animator.SetFloat(lastVertical, lastMovement.y);
    }
}