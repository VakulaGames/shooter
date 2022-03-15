using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : SteelArms
{
    public override void Take(Animator animator, CharacterStatus characterStatus)
    {
        base.Take(animator, characterStatus);
        animator.SetBool("takeSword", true);
    }

    public override void Away(Animator animator)
    {
        animator.SetBool("takeSword", false);
    }

    public override void Shoot(Animator animator, Transform lookTarget)
    {
        base.Shoot(animator, lookTarget);
    }
}
