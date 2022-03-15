using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AnimationEvents))]
[RequireComponent(typeof(CharacterIK))]
public class WeaponChange : MonoBehaviour
{
    [SerializeField] private CharacterStatus _characterStatus;
    [SerializeField] private Fists _fists;
    [SerializeField] private Gun _gun;
    [SerializeField] private AK74 _aK74;
    [SerializeField] private Katana _katana;
    [SerializeField] private Transform _rightHandPoint;

    public Weapon CurrentWeapon { get; private set; }
    private Weapon _lastWeapon;
    private Animator _animator;
    private AnimationEvents _animationEvent;
    private CharacterIK _charakterIK;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animationEvent = GetComponent<AnimationEvents>();
        _charakterIK = GetComponent<CharacterIK>();
        _animationEvent.OnTakeWeaponEvent += TakeWeapon;
        _animationEvent.OnAwayWeaponEvent += AwayWeapon;
        _animationEvent.OnWeaponTakenEvent += WeaponTaken;
        CurrentWeapon = _fists;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(_fists);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(_katana);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(_gun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeWeapon(_aK74);
        }
    }

    private void ChangeWeapon(Weapon newWeapon)
    {
        if (newWeapon != CurrentWeapon)
        {
            _lastWeapon = CurrentWeapon;
            CurrentWeapon.Away(_animator);
            _charakterIK.DisabledIK();
            CurrentWeapon = newWeapon;
            CurrentWeapon.Take(_animator, _characterStatus);
        }
    }

    private void TakeWeapon()
    {
        CurrentWeapon.transform.SetParent(_rightHandPoint, false);
    }

    private void AwayWeapon()
    {
        _lastWeapon.transform.SetParent(_lastWeapon.place, false);
    }

    private void WeaponTaken()
    {
        _animationEvent.RightHandPosition(CurrentWeapon.RightHandPosition, CurrentWeapon.RightHandRotation, CurrentWeapon.LeftHandTarget);
    }
}
