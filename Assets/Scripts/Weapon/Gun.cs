using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Gunshot
{
    public override void Take(Animator animator, CharacterStatus characterStatus)
    {
        base.Take(animator, characterStatus);
        animator.SetBool("takeGun", true);
    }

    public override void Away(Animator animator)
    {
        animator.SetBool("takeGun", false);
    }

    public override void Shoot(Animator animator, Transform lookTarget)
    {
        base.Shoot(animator, lookTarget);
    }
}
