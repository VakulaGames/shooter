using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] CharacterStatus _characterStatus;

    public bool debugAiming;
    public bool isAiming;

    public void InputUpdate()
    {
        if (debugAiming == false)
        {
            _characterStatus.isAiming = Input.GetMouseButton(1);
        }
        else
        {
            _characterStatus.isAiming = isAiming;
        }
    }
}
