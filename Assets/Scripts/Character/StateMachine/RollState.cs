using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : State
{
    private Animator _animator;

    public RollState (Animator animator)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetTrigger("roll");
    }
}
