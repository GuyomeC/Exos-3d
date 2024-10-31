using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorBinding : MonoBehaviour
{

    [SerializeField] InputActionReference _attack;

    [SerializeField, Required] Animator _animator;

    [SerializeField, Required] PlayerMove _move;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)]
    [SerializeField] string _isWalkingBoolParam;
    [SerializeField] HitEntity _hitEntity;

    private void Reset()
    {
        _animator = GetComponent<Animator>();
        _move = GetComponentInParent<PlayerMove>();
        _isWalkingBoolParam = "Walking";
    }

    private void Start()
    {
        _move.OnStartMove += _move_OnStartMove;
        _move.OnStopMove += _move_OnStopMove;
        _attack.action.started += StartAttack;
        _hitEntity.OnHit += ActiveHit;
    }


    private void OnDestroy()
    {
        _attack.action.started -= StartAttack;
        _hitEntity.OnHit -= ActiveHit;
    }

    private void _move_OnStartMove()
    {
        _animator.SetBool(_isWalkingBoolParam, true);
    }

    private void _move_OnStopMove()
    {
        _animator.SetBool(_isWalkingBoolParam, false);
    }

    private void StartAttack(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("Attack");
    }

    private void ActiveHit()
    {
        _animator.SetTrigger("GetHit");
    }

}
