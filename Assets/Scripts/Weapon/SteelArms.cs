using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelArms : Weapon
{
    public override void Take(Animator animator, CharacterStatus characterStatus)
    {
        characterStatus.isArmedGunshot = false;
        animator.SetBool("armedGunshot", false);
    }

    public override void Away(Animator animator)
    {

    }

    public override void Shoot(Animator animator, Transform lookTarget)
    {
        base.Shoot(animator, lookTarget);
    }
}
