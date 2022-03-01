using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : SteelArms
{
    public override void Take(Animator animator, CharacterStatus characterStatus)
    {
        base.Take(animator, characterStatus);
    }

    public override void Away(Animator animator)
    {
        
    }

    public override void Shoot(Animator animator)
    {
        base.Shoot(animator);
    }
}
