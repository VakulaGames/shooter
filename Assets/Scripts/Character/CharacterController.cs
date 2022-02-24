using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterController : MonoBehaviour
{
    private Animator _animator;
    private StateMachine _stateMachine;
    private WalkState _walkState;
    private RunState _runState;
    private JumpState _jumpState;
    private RollState _rollState;
    private SitState _sitState;


    private bool _isGroung;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new WalkState(this, _animator));
        _walkState = new WalkState(this, _animator);
        _runState = new RunState(this, _animator);
        _sitState = new SitState(this, _animator);
        _jumpState = new JumpState(_animator);
        _rollState = new RollState(_animator);
    }

    private void Update()
    {
        _stateMachine.currentState.Update();

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _stateMachine.ChangeState(_sitState);
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _stateMachine.ChangeState(_jumpState);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _stateMachine.ChangeState(_runState);

                if (Input.GetKeyDown(KeyCode.X))
                {
                    _stateMachine.ChangeState(_rollState);
                }
            }

            else
            {
                _stateMachine.ChangeState(_walkState);
            }
        }
    }
}
