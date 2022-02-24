using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private CharacterController _characterController;
    private Animator _animator;
    private Transform _cameraTransform;

    public MoveState(CharacterController characterController, Animator animator)
    {
        _characterController = characterController;
        _animator = animator;
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
        _animator.SetFloat("vertical", moveAmount, 0.15f, Time.deltaTime);

        Vector3 direction = MoveDirection(vertical, horizontal);

        RotationNormal(direction);
    }

    private Vector3 MoveDirection(float y, float x)
    {
        Vector3 direction = _cameraTransform.forward * y;
        direction += _cameraTransform.right * x;
        direction.Normalize();
        return direction;
    }

    private void RotationNormal(Vector3 direction)
    {
        Vector3 targetDir = direction;
        targetDir.y = 0;

        if (targetDir == Vector3.zero)
        {
            targetDir = _characterController.transform.forward;
        }

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(_characterController.transform.rotation, lookDir, 0.2f);
        _characterController.transform.rotation = targetRot;
    }
}
