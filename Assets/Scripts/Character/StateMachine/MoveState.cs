using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private MoveController _moveController;
    private Animator _animator;
    private Transform _cameraTransform;
    private CharacterStatus _characterStatus;

    public MoveState(MoveController moveController, Animator animator, CharacterStatus characterStatus)
    {
        _moveController = moveController;
        _animator = animator;
        _characterStatus = characterStatus;
        _cameraTransform = Camera.main.GetComponent<Transform>();
    }

    public override void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));
        
        if (_characterStatus.isArmedGunshot || _characterStatus.isAiming)
        {
            _animator.SetFloat("vertical", vertical);
            _animator.SetFloat("horizontal", horizontal);
            RotationNormal(_cameraTransform.forward);
        }
        else
        {
            _animator.SetFloat("vertical", moveAmount, 0.15f, Time.deltaTime);
            RotationNormal(NormalDirection(vertical, horizontal));
        }
    }
    private void RotationNormal(Vector3 direction)
    {
        Vector3 targetDir = direction;
        targetDir.y = 0;

        if (targetDir == Vector3.zero) targetDir = _moveController.transform.forward;

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(_moveController.transform.rotation, lookDir, 0.2f);
        _moveController.transform.rotation = targetRot;
    }

    private Vector3 NormalDirection(float y, float x)
    {
        Vector3 direction = _cameraTransform.forward * y;
        direction += _cameraTransform.right * x;
        direction.Normalize();
        return direction;
    }
}
