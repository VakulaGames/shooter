using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MoveState
{
    private Animator _animator;

    public RunState(MoveController characterController, Animator animator, CharacterStatus characterStatus) : base(characterController, animator, characterStatus)
    {
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetBool("run", true);
    }

    public override void Exit()
    {
        _animator.SetBool("run", false);
    }

    public override void Update()
    {
        base.Update();
    }
}
