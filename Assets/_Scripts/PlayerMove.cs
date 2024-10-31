using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] Rigidbody _rb;
    [SerializeField, Range(0, 100)]
    float _speed;


    public event Action OnStartMove;
    public event Action OnStopMove;


    Coroutine MovementRoutine { get; set; }

    private void Reset()
    {
        _rb = GetComponent<Rigidbody>();
        _speed = 10f;
    }

    private void OnValidate()
    {
        if(_speed <= 0)
        {
            Debug.LogWarning("Attention");
            _speed = 10;
        }
    }



    private void Start()
    {
        _move.action.started += StartMove;
        _move.action.canceled += StopMove;
    }
    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.canceled -= StopMove;
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        MovementRoutine = StartCoroutine(Move());
        IEnumerator Move()
        {
            OnStartMove?.Invoke();
            while (true)
            {
                var direction = obj.ReadValue<Vector2>();
                var v3 = new Vector3(direction.x, 0, direction.y);
                _rb.linearVelocity = v3 * _speed;

                yield return null;
            }
        }
    }

    private void StopMove(InputAction.CallbackContext obj)
    {
        OnStopMove?.Invoke();
        _rb.linearVelocity = Vector3.zero;

        StopCoroutine(MovementRoutine);
        MovementRoutine = null;
    }
}
