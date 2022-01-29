using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Instancing

    public static Inventory instance;

    void Awake()
    {
        if (instance != null) {
            Debug.Log("More than one instance of inventory found...");
            return;
        }
        instance = this;
    }

    #endregion

    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged oicCallback;
    public int encumbrance = 20;

    public bool Add(Item item) 
    {
        if (!item.isStandard) {
            if (items.Count >= encumbrance) {
                Debug.Log("Player Overencumbered. Could not pick up Item");
                return false;
            }

            items.Add(item);
            
            if (oicCallback != null)
                oicCallback.Invoke();
            
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (oicCallback != null)
            oicCallback.Invoke();
    }
}
