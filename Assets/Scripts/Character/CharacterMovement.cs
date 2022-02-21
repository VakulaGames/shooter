using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speedRotate = 0.2f;
    [SerializeField] private float _speedMove = 1f;

    private Transform _cameraTransform;
    private Animator _animator;

    private void Start()
    {
        _cameraTransform = Camera.main.GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }

    public void Move(float vertical, float horizontal, bool isHandsEmpty)
    {
        float moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));

        _animator.SetFloat("vertical", moveAmount,0.15f ,Time.deltaTime * _speedMove);

        Vector3 rotationDirection;

        if (isHandsEmpty == true)
        {
            rotationDirection = MoveDirection(vertical, horizontal);
        }
        else
        {
            rotationDirection = _cameraTransform.forward;
        }

        RotationNormal(rotationDirection);
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
            targetDir = transform.forward;
        }

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, _speedRotate);
        transform.rotation = targetRot;
    }
}
