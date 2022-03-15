using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveController : MonoBehaviour
{
    public bool debugAiming;
    [SerializeField] private CharacterStatus _characterStatus;
    private Animator _animator;
    private StateMachine _stateMachine;
    private WalkState _walkState;
    private RunState _runState;
    private JumpState _jumpState;
    private RollState _rollState;
    private SitState _sitState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new WalkState(this, _animator, _characterStatus));
        _walkState = new WalkState(this, _animator, _characterStatus);
        _runState = new RunState(this, _animator, _characterStatus);
        _sitState = new SitState(this, _animator, _characterStatus);
        _jumpState = new JumpState(_animator);
        _rollState = new RollState(_animator);
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentState.Update();
    }

    private void Update()
    {
        if (debugAiming == true)
        {
            _characterStatus.isAiming = true;
            _animator.SetBool("aiming", true);
        }
        else
        {
            _characterStatus.isAiming = Input.GetMouseButton(1);
            _animator.SetBool("aiming", Input.GetMouseButton(1));
        }
        
        if (Input.GetKey(KeyCode.LeftControl)) _stateMachine.ChangeState(_sitState);

        else
        {
            if (Input.GetKeyDown(KeyCode.Space)) _stateMachine.ChangeState(_jumpState);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _stateMachine.ChangeState(_runState);

                if (Input.GetKeyDown(KeyCode.X)) _stateMachine.ChangeState(_rollState);
            }

            else _stateMachine.ChangeState(_walkState);
        }
    }
}
