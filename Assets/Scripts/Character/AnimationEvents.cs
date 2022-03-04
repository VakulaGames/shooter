using System;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public event Action OnTakeWeaponEvent;
    public event Action OnAwayWeaponEvent;
    public event Action OnWeaponTakenEvent;
    public event Action<Vector3, Vector3, Transform> OnRightHandPositionEvent;

    public void TakeWeapon()
    {
        this.OnTakeWeaponEvent?.Invoke();
    }

    public void AwayWeapon()
    {
        this.OnAwayWeaponEvent?.Invoke();
    }
    
    public void WeaponTaken()
    {
        this.OnWeaponTakenEvent?.Invoke();
    }

    public void RightHandPosition(Vector3 rightHandPosition, Vector3 rightHandRotation, Transform leftHandTarget)
    {
        this.OnRightHandPositionEvent?.Invoke(rightHandPosition, rightHandRotation, leftHandTarget);
    }
}
