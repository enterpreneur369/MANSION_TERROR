using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string pWalking = "Walking";
    private Rigidbody2D _playerRigidBody;
    private Animator _animator;
    public static bool playerCreated;
    public string nextPlaceName;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody2D>();

        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;
        // distance = speed * time
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
        {
            /*
            this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal) * speed *
                                                 Time.deltaTime, 0, 0));*/
            _playerRigidBody.velocity = new Vector2(Input.GetAxisRaw(horizontal) * speed, 
                _playerRigidBody.velocity.y);
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0);
        }
        
        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            /*
            this.transform.Translate(new Vector3(0, Input.GetAxisRaw(vertical) * speed *
                                                   Time.deltaTime, 0));*/
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, 
                Input.GetAxisRaw(vertical) * speed);
            walking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));
        }

        if (!walking)
        {
            _playerRigidBody.velocity = Vector2.zero;
        }
        

        _animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        _animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
        _animator.SetBool(pWalking, walking);
        _animator.SetFloat(lastHorizontal, lastMovement.x);
        _animator.SetFloat(lastVertical, lastMovement.y);
    }
}
