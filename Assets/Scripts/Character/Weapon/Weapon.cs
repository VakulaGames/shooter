using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon:MonoBehaviour
{
    public Transform place;

    [SerializeField] private Vector3 _righHandPosition;
    [SerializeField] private Vector3 _rightHandRotation;
    [SerializeField] private Transform _leftHandTarget;
    public Vector3 RightHandPosition { get { return _righHandPosition; } }
    public Vector3 RightHandRotation { get { return _rightHandRotation; } }
    public Transform LeftHandTarget { get { return _leftHandTarget; } }

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
