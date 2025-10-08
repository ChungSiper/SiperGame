using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private StateMachine _stateMachine;

    #region Dtection flags
    private bool _isGrounDetect = true;
    private bool _isWallDetect = true;
    #endregion

    #region Serialized fields
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    #endregion
    #region Detected Ground
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _wallLayer;
    #endregion

    #region Input Variables
    private Vector2 _moveInput;
    private float _jumpInput;
    #endregion
    #region Properties
    public Vector2 MoveInput => _moveInput;
    public float JumpInput => _jumpInput;
    public Rigidbody2D rb => _rb;
    public Animator anim => _anim;
    public StateMachine stateMachine => _stateMachine;
    public float moveSpeed => _moveSpeed;
    public float jumpForce => _jumpForce;
    public bool isGroundDetect => _isGrounDetect;
    public bool isWallDetect => _isWallDetect;
    #endregion

    #region States
    public IdlePlayer1State IdlePlayer1State;
    public RunPlayer1State RunPlayer1State;
    public WalkPlayer1State WalkPlayer1State;
    #endregion
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _stateMachine = new StateMachine();

        _stateMachine.ChangeState(new IdlePlayer1State(this));
        IdlePlayer1State = new IdlePlayer1State(this);
        RunPlayer1State = new RunPlayer1State(this);
        
    }
    void Update()
    {
        _stateMachine.CurrentState.Update();
        DetectGround();
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
        //SetFacingDiretion(_moveInput.x);
        //rb.linearVelocity = new Vector2(_moveInput.x * _moveSpeed, rb.linearVelocity.y);
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        _jumpInput = ctx.ReadValue<float>();
    }
    public void SetFacingDiretion(float direction)
    {
        if (direction > 0)
            transform.localScale = new Vector2(1, 1);
        else if (direction < 0)
            transform.localScale = new Vector2(-1, 1);
    }
    private void DetectGround()
    {
        _isGrounDetect = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

}
