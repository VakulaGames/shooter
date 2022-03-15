using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _cameraFreeLook;
    [SerializeField] private CharacterStatus _characterStatus;
    [SerializeField] private Transform _lookTarget;
    [SerializeField] private Transform _anchor;
    [SerializeField] private float _anchorDistance;
    [SerializeField] private float _displacementSpeed;
    [SerializeField] private float _zoomMin;
    [SerializeField] private float _zoomSpeed;

    public Transform LookTargetPosition { get => _lookTarget; private set { }}

    private Transform _cameraMain;

    private void Start()
    {
        _cameraMain = Camera.main.GetComponent<Transform>();
    }

    private void Update()
    {
        CameraDisplacement(_characterStatus.isArmedGunshot);
        CameraAiming(_characterStatus.isAiming);
        LookTargetMoving();
    }

    private void CameraDisplacement(bool isArmedGunshot)
    {
        if (isArmedGunshot == true)
        {
            if (_anchor.localPosition.x < _anchorDistance)
            {
                _anchor.localPosition += Vector3.right * _displacementSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (_anchor.localPosition.x > 0)
            {
                _anchor.localPosition += Vector3.left * _displacementSpeed * Time.deltaTime;
            }
        }
    }

    private void CameraAiming(bool isAiming)
    {
        if (isAiming == true)
        {
            if (_cameraFreeLook.m_Lens.FieldOfView > _zoomMin)
            {
                _cameraFreeLook.m_Lens.FieldOfView -= _zoomSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (_cameraFreeLook.m_Lens.FieldOfView < 40)
            {
                _cameraFreeLook.m_Lens.FieldOfView += _zoomSpeed * Time.deltaTime;
            }
        }
    }

    private void LookTargetMoving()
    {
        Ray ray = new Ray(_cameraMain.position, _cameraMain.forward * 2000);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            _lookTarget.position = Vector3.Lerp(_lookTarget.position, hit.point, Time.deltaTime * 40);
        }
        else
        {
            _lookTarget.position = Vector3.Lerp(_lookTarget.position, _cameraMain.forward * 200, Time.deltaTime * 40);
        }
    }
}
