using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterStatus _characterStatus;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private float _damp = 0.25f;

    public void AnimationUpdate(float vertical, float horizontal)
    {
        _animator.SetBool("sprint", _characterStatus.isSprint);
        _animator.SetBool("aiming", _characterStatus.isAiming);

        if (_characterStatus.isAiming == false)
        {
            AnimationNormal();
        }
        else
        {
            AnimationAiming(vertical,horizontal);
        }
    }

    private void AnimationNormal()
    {
        //_animator.SetFloat("vertical", _characterMovement._moveAmount, _damp, Time.deltaTime);
    }

    private void AnimationAiming(float vertical, float horizontal)
    {
        _animator.SetFloat("vertical", vertical, _damp, Time.deltaTime);
        _animator.SetFloat("horizontal", horizontal, _damp, Time.deltaTime);
    }
}
