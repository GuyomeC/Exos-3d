using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] UnityEvent _destroyFeedback;

    public virtual void Use(PickUpItem pui)
    {
        // consume bag

        _destroyFeedback?.Invoke();
        Destroy(gameObject, 3f);
    }

}
