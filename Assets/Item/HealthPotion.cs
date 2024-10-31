using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{

    [SerializeField] private int _healthAmount = 30;


    public override void Use(PickUpItem pui)
    {

        EntityHealth entityHealth = pui.GetComponentInParent<EntityHealth>();

        if (entityHealth != null)
        {
            entityHealth.AddHealth(_healthAmount);
        }
        Debug.Log(pui.gameObject.name + " a ramassé de la vie");

        base.Use(pui);



    }

}
