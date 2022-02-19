using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private CharacterStatus _characterStatus;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _speedRotate = 0.2f;
    [SerializeField] private float _speedMove = 1f;


    public float _vertical;
    public float _horizontal;
    public float _moveAmount;

    private Vector3 _rotationDirection;
    private Vector3 _moveDirection;

    public void MoveUpdate()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
        _moveAmount = Mathf.Clamp01(Mathf.Abs(_vertical) + Mathf.Abs(_horizontal));

        Vector3 moveDir = _cameraTransform.forward * _vertical;
        moveDir += _cameraTransform.right * _horizontal;
        moveDir.Normalize();
        _moveDirection = moveDir;
        _rotationDirection = _cameraTransform.forward;

        RotationNormal();
    }

    public void RotationNormal()
    {
        if (_characterStatus.isAiming == false)
        {
            _rotationDirection = _moveDirection;
        }

        Vector3 targetDir = _rotationDirection;
        targetDir.y = 0;

        if (targetDir == Vector3.zero)
        {
            targetDir = transform.forward;
        }

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, _speedRotate);
        transform.rotation = targetRot;
    }
}
