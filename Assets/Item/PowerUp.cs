using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{

    [SerializeField] private int _damageAmount = 30;

    public override void Use(PickUpItem pui)
    {
        Transform parentTransform = pui.transform.parent;
        if (parentTransform != null)
        {
            // Rechercher le composant 'HitEntity' sur l'objet parent ou ses enfants
            HitEntity hitEntity = parentTransform.GetComponentInChildren<HitEntity>();

            if (hitEntity != null)
            {
                hitEntity.AddDamageAmount(_damageAmount);
            }
            Debug.Log(pui.gameObject.name + " a ramassé un bonus de dégat");


            base.Use(pui);
        }

    }
}
