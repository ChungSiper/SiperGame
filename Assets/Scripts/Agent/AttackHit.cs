using UnityEditor;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    [SerializeField] private float damage;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<IDamageable>(out var component))
        {
            component.OnDamage(damage);
        }
        var controller = GetComponentInParent<AgentController>();
        if (controller != null)
        {
            controller.PlayHitSound();
        }
    }

}