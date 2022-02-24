using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MoveState
{
    public WalkState(CharacterController characterController, Animator animator) : base(characterController, animator)
    {

    }

    public override void Update()
    {
        base.Update();
    }
}
