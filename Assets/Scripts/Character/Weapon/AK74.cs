using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK74 : Gunshot
{
    public override void Take(Animator animator, CharacterStatus characterStatus)
    {
        base.Take(animator, characterStatus);
        animator.SetBool("takeMachine", true);
    }

    public override void Away(Animator animator)
    {
        animator.SetBool("takeMachine", false);
    }

    public override void Shoot(Animator animator)
    {
        base.Shoot(animator);
    }
}
