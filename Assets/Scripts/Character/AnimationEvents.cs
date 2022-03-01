using System;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public event Action OnTakeWeaponEvent;
    public event Action OnAwayWeaponEvent;

    public void TakeWeapon()
    {
        this.OnTakeWeaponEvent?.Invoke();
    }

    public void AwayWeapon()
    {
        this.OnAwayWeaponEvent?.Invoke();
    }
}
