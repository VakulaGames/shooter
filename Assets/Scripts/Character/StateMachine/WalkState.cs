using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MoveState
{
    public WalkState(MoveController characterController, Animator animator, CharacterStatus characterStatus) : base(characterController, animator, characterStatus)
    {

    }

    public override void Update()
    {
        base.Update();
    }
}
