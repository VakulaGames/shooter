using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIK : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private CharacterInventory _characterInventory;
    [SerializeField] private CharacterStatus _characterStatus;
    //[SerializeField] private Transform _targetLook;
    [SerializeField] private Transform _lHandTarget;
    [SerializeField] private float _handSpeed;

    private Transform _lHand;
    private Transform _rHand;
    private Quaternion _lhRot;

    public float _rhWeight; //временно публичная

    private Transform _shoulder;
    private Transform _aimPivot;

    private void Start()
    {
        _shoulder = _animator.GetBoneTransform(HumanBodyBones.RightShoulder).transform;

        _aimPivot = new GameObject().transform;
        _aimPivot.name = "aim pivot";
        _aimPivot.transform.parent = transform;

        _rHand = new GameObject().transform;
        _rHand.name = "right hand";
        _rHand.transform.parent = _aimPivot;

        _lHand = new GameObject().transform;
        _lHand.name = "left hand";
        _lHand.transform.parent = _aimPivot;

        _rHand.localPosition = _characterInventory.firstWeapon.rHandPos;
        Quaternion rotRight = Quaternion.Euler(_characterInventory.firstWeapon.rHandRot.x, _characterInventory.firstWeapon.rHandRot.y, _characterInventory.firstWeapon.rHandRot.z);
        _rHand.localRotation = rotRight;
    }

    private void Update()
    {
        _lhRot = _lHandTarget.rotation;
        _lHand.position = _lHandTarget.position;

        if (_characterStatus.isAiming == true)
        {
            _rhWeight += Time.deltaTime * _handSpeed;
        }
        else
        {
            _rhWeight -= Time.deltaTime * _handSpeed;
        }
        _rhWeight
             = Mathf.Clamp(_rhWeight, 0, 1);
    }

    private void OnAnimatorIK()
    {
        _aimPivot.position = _shoulder.position;

        if(_characterStatus.isAiming == true)
        {
            //_aimPivot.LookAt(_targetLook);

            _animator.SetLookAtWeight(.3f, .5f, .8f);
            //_animator.SetLookAtPosition(_targetLook.position);

            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _lHand.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _lhRot);

            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _rhWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _rhWeight);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _rHand.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _rHand.rotation);
        }
        else
        {
            _animator.SetLookAtWeight(.3f, .3f, .8f);
            //_animator.SetLookAtPosition(_targetLook.position);

            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _lHand.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _lhRot);

            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _rhWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _rhWeight);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _rHand.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _rHand.rotation);
        }
    }
}
