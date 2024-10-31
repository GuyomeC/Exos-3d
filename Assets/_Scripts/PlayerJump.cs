using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] InputActionReference _jump;
    [SerializeField] Rigidbody _rb;
    [SerializeField, Range(0, 100)]
    float _speed;

    private void Reset()
    {
        _rb = GetComponent<Rigidbody>();
        _speed = 10f;
    }

    private void OnValidate()
    {
        if (_speed <= 0)
        {
            Debug.LogWarning("Attention");
            _speed = 10;
        }
    }


    private void Start()
    {
        _jump.action.canceled += StartJump;
    }
    private void OnDestroy()
    {
        _jump.action.canceled -= StartJump;
    }

    private void StartJump(InputAction.CallbackContext obj)
    {
        var v3 = new Vector3(0, 1, 0);
        _rb.linearVelocity = v3 * _speed;
    }
}
