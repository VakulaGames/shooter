using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour //Change for Test Git
{
    public bool leftPivot;

    [SerializeField] private Transform _camTransform;
    [SerializeField] private Transform _pivot;
    [SerializeField] private Transform _character;
    [SerializeField] private Transform _camHolderTransform;

    [SerializeField] private CharacterStatus _characterStatus;
    [SerializeField] private CameraConfig _cameraConfig;

    private float _mouseX;
    private float _mouseY;
    private float _smoothX;
    private float _smoothY;
    private float _smoothXVelocity;
    private float _smoothYVelocity;
    private float _lookAngle;
    private float _titleAngle;

    private void Update()
    {
        FixedTick();
    }

    private void FixedTick()
    {
        HandlePosition();
        HandleRotation();

        Vector3 targetPosition = Vector3.Lerp(_camHolderTransform.position, _character.position, 1);
        _camHolderTransform.position = targetPosition;
    }

    private void HandlePosition()
    {
        float targetX = _cameraConfig.normalX;
        float targetY = _cameraConfig.normalY;
        float targetZ = _cameraConfig.normalZ;

        if (_characterStatus.isAiming == true)
        {
            targetX = _cameraConfig.aimX;
            targetZ = _cameraConfig.aimZ;
        }

        if (leftPivot == true)
        {
            targetX = -targetX;
        }

        Vector3 newPivotPosition = _pivot.localPosition;
        newPivotPosition.x = targetX;
        newPivotPosition.y = targetY;

        Vector3 newCameraPosition = _camTransform.localPosition;
        newCameraPosition.z = targetZ;

        float t = _cameraConfig.pivotSpeed * Time.deltaTime;
        _pivot.localPosition = Vector3.Lerp(_pivot.localPosition, newPivotPosition, t);
        _camTransform.localPosition = Vector3.Lerp(_camTransform.localPosition, newCameraPosition, t);
    }

    private void HandleRotation()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        if (_cameraConfig.turnSmooth > 0)
        {
            _smoothX = Mathf.SmoothDamp(_smoothX, _mouseX, ref _smoothXVelocity, _cameraConfig.turnSmooth);
            _smoothY = Mathf.SmoothDamp(_smoothY, _mouseY, ref _smoothYVelocity, _cameraConfig.turnSmooth);
        }
        else
        {
            _smoothX = _mouseX;
            _smoothY = _mouseY;
        }

        _lookAngle += _smoothX * _cameraConfig.yRotSpeed;
        Quaternion targetRot = Quaternion.Euler(0, _lookAngle, 0);
        _camHolderTransform.rotation = targetRot;

        _titleAngle -= _smoothY * _cameraConfig.xRotSpeed;
        _titleAngle = Mathf.Clamp(_titleAngle, _cameraConfig.minAngle, _cameraConfig.maxAngle);
        _pivot.localRotation = Quaternion.Euler(_titleAngle, 0, 0);
    }
}
