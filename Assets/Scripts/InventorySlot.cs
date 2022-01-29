using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;

    public Image icon;
    public Button dropButton;

    public void AddItem(Item _item)
    {
        item = _item;

        icon.sprite = item.icon;
        icon.enabled = true;
        dropButton.interactable = true;
    }
    
    public void DropItem()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        dropButton.interactable = false;
    }

    public void OnDropButtonPress()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null) {
            item.Use();
        }
    }
}
