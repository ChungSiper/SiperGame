using System.Collections;
using UnityEngine;
public class AnimationEvent : MonoBehaviour
{
    private PlayerController _player;
    // Use this for initialization
    private void Awake()
    {
        _player = GetComponent<PlayerController>();
    }
    public void AttackFinish()
    {
        _player.CallAnimationEvent();
    }
}
