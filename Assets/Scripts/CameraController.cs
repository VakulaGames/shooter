using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _cameraArmedGunshot;
    [SerializeField] private CinemachineFreeLook _cameraAiming;
    [SerializeField] private CharacterStatus _characterStatus;

    private void Update()
    {
        if (_characterStatus.isArmedGunshot == true) _cameraArmedGunshot.Priority = 3;
        else _cameraArmedGunshot.Priority = 1;

        if (_characterStatus.isAiming == true) _cameraAiming.Priority = 4;
        else _cameraAiming.Priority = 1;
    }
}
