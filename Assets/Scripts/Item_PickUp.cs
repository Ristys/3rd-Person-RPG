using System.Diagnostics;
using UnityEngine;

public class Item_PickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        UnityEngine.Debug.Log("Picked up item:" + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
            Destroy(gameObject);
    }
}
