using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private InputHandler _inputHandler;
    private CharacterMovement _characterMovement;
    private CharacterAnimation _characterAnimation;

    private bool _isHandsEmpty = true;
    
    private void Start()
    {
        _inputHandler = GetComponent<InputHandler>();
        _characterMovement = GetComponent<CharacterMovement>();
        _characterAnimation = GetComponent<CharacterAnimation>();
    }

    private void Update()
    {
        _characterMovement.Move(_inputHandler.VerticalAxis(), _inputHandler.HorizontalAxis(), _isHandsEmpty);
        //_characterAnimation.AnimationUpdate(_inputHandler.VerticalAxis(), _inputHandler.HorizontalAxis());
    }
}
