using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitState : MoveState
{
    private Animator _animator;

    public SitState(MoveController characterController, Animator animator, CharacterStatus characterStatus) : base(characterController, animator, characterStatus)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetBool("sitting", true);
    }

    public override void Exit()
    {
        _animator.SetBool("sitting", false);
    }

    public override void Update()
    {
        base.Update();
    }
}
