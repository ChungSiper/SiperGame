using System.Collections.Generic;
using UnityEngine;


public class AgentController : MonoBehaviour
{
    protected Rigidbody2D _rb;
    protected Animator _anim;
    protected StateMachine _stateMachine;
    public Rigidbody2D RB => _rb;
    public Animator anim => _anim;
    public StateMachine StateMachine => _stateMachine;

    #region Dtection flags
    private bool _isGrounDetect = true;
    private bool _isWallDetect = true;
    public bool isGroundDetect => _isGrounDetect;
    public bool isWallDetect => _isWallDetect;
    #endregion

    #region Serialized Fields
    [SerializeField] private float _groundDetectDistance = 0.7f;
    [SerializeField] private float _wallDetectDistance = 0.3f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _wallLayer;
    [SerializeField] private Transform _detectGameObject;
    #endregion
    public float FacingDirection => transform.localScale.x;
    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _stateMachine = new StateMachine();

        
    }
    void Update()
    {
        _stateMachine.CurrentState.Update();
        DetectGround();
        DetectWall();
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
        List<RaycastHit2D> hit = new();
        var filter = new ContactFilter2D
        {
            layerMask = _groundLayer,
            useLayerMask = true
        };
        if (Physics2D.Raycast(_detectGameObject.position, Vector2.down * FacingDirection, filter, hit, _groundDetectDistance) > 0)
        {
            _isGrounDetect = true;
        }
        else
        {
            _isGrounDetect = false;
        }
    }
    private void DetectWall()
    {
        List<RaycastHit2D> hit = new();
        var filter = new ContactFilter2D
        {
            layerMask = _wallLayer,
            useLayerMask = true
        };
        if (Physics2D.Raycast(_detectGameObject.position, Vector2.right * FacingDirection, filter, hit, _wallDetectDistance) > 0)
        {
            _isWallDetect = true;
        }
        else
        {
            _isWallDetect = false;
        }
    }
    public void TriggerAnimatonEvent()
    {
        _stateMachine.CurrentState.TriggerAnimationEvent();
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_detectGameObject.position, _detectGameObject.position + Vector3.down * _groundDetectDistance);
        Gizmos.DrawLine(_detectGameObject.position, _detectGameObject.position + Vector3.right * _wallDetectDistance * FacingDirection);

    }
}