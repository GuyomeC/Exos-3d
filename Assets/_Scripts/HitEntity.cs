using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] public int _damage;
    private BoxCollider attackZone;

    private EntityHealth _entityHealth;


    public event Action OnHit;


    private void Awake()
    {
        attackZone = GetComponent<BoxCollider>();

        if (attackZone == null || !attackZone.isTrigger && this.gameObject.layer != LayerMask.NameToLayer("HitPlayer"))
        {
            Debug.LogError("Le BoxCollider est soit manquant, soit n'est pas en trigger sur " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && this.gameObject.layer == LayerMask.NameToLayer("HitPlayer"))
        {
            EntityHealth entityHealth = other.GetComponentInParent<EntityHealth>();
            if (entityHealth != null)
            {
                entityHealth.RemoveHealth(_damage);
                if (OnHit == null)
                {
                    Debug.Log("je suis vide");
                }
                OnHit?.Invoke();
            }
        }
    }

    public void PerformAttack()
    {
        if (attackZone == null)
        {
            Debug.LogWarning("Pas de zone d'attaque d�finie !");
            return;
        }

        // R�cup�re tous les objets dans la zone de trigger
        Collider[] hits = Physics.OverlapBox(attackZone.bounds.center, attackZone.bounds.extents, attackZone.transform.rotation);

        foreach (Collider hit in hits)
        {

            if (hit.gameObject.layer == LayerMask.NameToLayer("PickUp"))
            {
                continue; // Ignore le joueur lui-m�me
            }

            EntityHealth entityHealth = hit.GetComponentInParent<EntityHealth>();
            if (entityHealth != null)
            {
                entityHealth.RemoveHealth(_damage);
                Debug.Log("Ennemi touch� !");
                break;
            }
        }
    }

    public void AddDamageAmount(int amount)
    {
        _damage += amount;
    }
}
