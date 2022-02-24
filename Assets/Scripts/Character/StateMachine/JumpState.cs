using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private Animator _animator;

    public JumpState (Animator animator)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetTrigger ("jump");
    }
}
