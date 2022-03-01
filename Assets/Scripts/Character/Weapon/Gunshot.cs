using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : Weapon
{
    public override void Take(Animator animator, CharacterStatus characterStatus)
    {
        characterStatus.isArmedGunshot = true;
        animator.SetBool("armedGunshot", true);
    }

    public override void Away(Animator animator)
    {

    }

    public override void Shoot(Animator animator)
    {
        base.Shoot(animator);
    }
}
