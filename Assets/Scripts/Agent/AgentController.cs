using System.Collections.Generic;
using UnityEngine;


public class AgentController : MonoBehaviour
{
    protected StateMachine _stateMachine;
    public StateMachine StateMachine => _stateMachine;
    protected Rigidbody2D _rb;
    public Rigidbody2D RB => _rb;
    protected Animator _anim;
    public Animator anim => _anim;

    #region Dtection flags
    private bool _isGrounDetect;
    private bool _isWallDetect;
    public bool isGroundDetect => _isGrounDetect;
    public bool isWallDetect => _isWallDetect;
    #endregion

    #region Serialized Fields
    [SerializeField] protected float _health = 100f;
    [SerializeField] protected float _groundDetectDistance = 0.7f;
    [SerializeField] protected float _wallDetectDistance = 0.3f;
    [SerializeField] protected LayerMask _groundLayer;
    [SerializeField] protected LayerMask _wallLayer;
    [SerializeField] protected Transform _detectGameObject;
    [SerializeField] protected HealthBar _healthBar;
    #endregion
    public float FacingDirection => transform.localScale.x;
    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _stateMachine = new StateMachine();

        _healthBar.Initialize(_health);
        _healthBar.SetValue(_health);

    }
    void Update()
    {
        _stateMachine.CurrentState.Update();
        DetectGround();
        DetectWall();
    }
    public void SetFacingDiretion(float direction)
    {
        if (direction == 0)
        {
            return;
        }
        if (direction > 0 != transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1f, 1f);
            //_healthBar.transform.localScale *= new Vector2(-1f, 1f);
        }
    }

    private void DetectGround()
    {
        List<RaycastHit2D> hit = new();
        var filter = new ContactFilter2D
        {
            layerMask = _groundLayer,
            useLayerMask = true
        };
        if (Physics2D.Raycast(_detectGameObject.position, Vector2.down, filter, hit, _groundDetectDistance) > 0)
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
    public void TriggerAnimationEvent()
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