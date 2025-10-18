using System;
using UnityEngine;
[Serializable]
public class Player1StateBase : AgentStateBase
{
    protected PlayerController _player;
    public Player1StateBase(PlayerController playerController) : base(playerController)
    {
        _player = playerController;
    }
}
