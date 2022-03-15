using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : Weapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bullet;

    public override void Take(Animator animator, CharacterStatus characterStatus)
    {
        characterStatus.isArmedGunshot = true;
        animator.SetBool("armedGunshot", true);
    }

    public override void Away(Animator animator)
    {

    }

    public override void Shoot(Animator animator, Transform lookTarget)
    {
        base.Shoot(animator, lookTarget);
        _shootPoint.LookAt(lookTarget);
        Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
    }
}
