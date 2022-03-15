using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(WeaponChange))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private CameraController _cameraController;

    private WeaponChange _weaponChange;
    private Animator _animator;

    private void Start()
    {
        _weaponChange = GetComponent<WeaponChange>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _weaponChange.CurrentWeapon.Shoot(_animator, _cameraController.LookTargetPosition);
        }
    }
}
