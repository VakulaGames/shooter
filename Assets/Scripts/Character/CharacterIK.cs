using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AnimationEvents))]
public class CharacterIK : MonoBehaviour
{
    [SerializeField] private CharacterStatus _characterStatus;
    [SerializeField] private Transform _targetLook;
    
    private Animator _animator;
    private AnimationEvents _animationEvent;

    private float _rightHandWeight;
    private Transform _leftHand;
    private Transform _leftHandTarget;
    private Quaternion _leftHandRotation;
    private Transform _rightHand;
    private Transform _shoulder;
    private Transform _aimPivot;
    private bool _isEnabledIK;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animationEvent = GetComponent<AnimationEvents>();

        _shoulder = _animator.GetBoneTransform(HumanBodyBones.RightShoulder).transform;

        _aimPivot = new GameObject().transform;
        _aimPivot.name = "aim pivot";
        _aimPivot.transform.parent = transform;

        _rightHand = new GameObject().transform;
        _rightHand.name = "right hand";
        _rightHand.transform.parent = _aimPivot;

        _leftHand = new GameObject().transform;
        _leftHand.name = "left hand";
        _leftHand.transform.parent = _aimPivot;

        _animationEvent.OnRightHandPositionEvent += GetRightHandPosition;
    }

    private void Update()
    {
        if (_isEnabledIK == true)
        {
            if (_rightHandWeight <= 1) _rightHandWeight += Time.deltaTime * 2;
        }
        else
        {
            if (_rightHandWeight >= 0) _rightHandWeight -= Time.deltaTime * 2;
        }

        _leftHandRotation = _leftHandTarget.rotation;
        _leftHand.position = _leftHandTarget.position;
    }

    public void DisabledIK()
    {
        _isEnabledIK = false;
    }

    private void OnAnimatorIK()
    {
        _aimPivot.position = _shoulder.position;

        if (_characterStatus.isArmedGunshot)
        {
            _aimPivot.LookAt(_targetLook);

            _animator.SetLookAtWeight(1, 0, 1);
            _animator.SetLookAtPosition(_targetLook.position);

            if (_isEnabledIK == true)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHand.position);
                _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandRotation);

                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _rightHandWeight);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _rightHandWeight);
                _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHand.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHand.rotation);
            }  
        }
        else
        {
            _animator.SetLookAtWeight(1, 0.2f, 0.5f);
            _animator.SetLookAtPosition(_targetLook.position);
        }
        
    }

    private void GetRightHandPosition(Vector3 rightHandPosition, Vector3 rightHandRotation, Transform leftHandTarget)
    {
        _rightHand.localPosition = rightHandPosition;
        _rightHand.localRotation = Quaternion.Euler(rightHandRotation.x, rightHandRotation.y, rightHandRotation.z);
        _leftHandTarget = leftHandTarget;

        _isEnabledIK = true;
    }
}
