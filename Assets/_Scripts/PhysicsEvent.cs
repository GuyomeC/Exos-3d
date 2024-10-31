using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsEvent : MonoBehaviour
{
    [SerializeField] UnityEvent _onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        _onTriggerEnter.Invoke();
    }


    private void OnTriggerStay(Collider other)
    {
        
    }


}
