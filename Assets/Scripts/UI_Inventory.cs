using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    Inventory inventory;
    public Transform itemBag;
    InventorySlot[] slots;

    public GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.oicCallback += UpdateUI;

        slots = itemBag.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")) {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++) {
            if (i < inventory.items.Count) {
                slots[i].AddItem(inventory.items[i]);
            } else {
                slots[i].DropItem();
            }
        }
    }
}
