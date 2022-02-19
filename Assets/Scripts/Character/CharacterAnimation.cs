using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterStatus _characterStatus;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private float _damp = 0.25f;

    public void AnimationUpdate()
    {
        _animator.SetBool("sprint", _characterStatus.isSprint);
        _animator.SetBool("aiming", _characterStatus.isAiming);

        if (_characterStatus.isAiming == false)
        {
            AnimationNormal();
        }
        else
        {
            AnimationAiming();
        }
    }

    private void AnimationNormal()
    {
        _animator.SetFloat("vertical", _characterMovement._moveAmount, _damp, Time.deltaTime);
    }

    private void AnimationAiming()
    {
        float v = _characterMovement._vertical;
        float h = _characterMovement._horizontal;

        _animator.SetFloat("vertical", v, _damp, Time.deltaTime);
        _animator.SetFloat("horizontal", h, _damp, Time.deltaTime);
    }
}
