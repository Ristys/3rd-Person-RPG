
using UnityEngine;


// characteristics to be shared amongst all items

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isStandard = false;

    public virtual void Use()
    {
        // create override for each item
        Debug.Log("Using" + name);
    }
}
