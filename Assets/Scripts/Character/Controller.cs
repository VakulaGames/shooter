using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private CharacterAnimation _characterAnimation;
    [SerializeField] private CharacterInput _characterInput;

    public void Update()
    {
        _characterMovement.MoveUpdate();
        _characterAnimation.AnimationUpdate();
        _characterInput.InputUpdate();
    }
}
