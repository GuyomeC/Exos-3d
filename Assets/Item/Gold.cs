using UnityEngine;

public class Gold : Item
{
    [SerializeField] private int _goldAmount = 10; // Montant d'or donné par cet objet Gold

    public override void Use(PickUpItem pui)
    {
        EntityGold entityGold = pui.GetComponentInParent<EntityGold>();

        if (entityGold != null)
        {
            entityGold.AddGold(_goldAmount);
        }

        Debug.Log(pui.gameObject.name + " a ramassé de l'or");
        base.Use(pui);
    }
}
