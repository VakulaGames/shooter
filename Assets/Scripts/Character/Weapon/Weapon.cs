using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon:MonoBehaviour
{
    public Transform place;
    [SerializeField] private int _damage;
    [SerializeField] private float _timeBetweenShoot;

    public virtual void Take(Animator animator, CharacterStatus characterStatus)
    {

    }

    public virtual void Away(Animator animator)
    {

    }

    public virtual void Shoot(Animator animator)
    {
        animator.SetTrigger("shoot");
    }
}
