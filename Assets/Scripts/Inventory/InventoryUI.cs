using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private int itemSelected = 1;
    public Transform itemsParent;
    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        Debug.Log("UPDATING UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                if(inventory.items.Count == 1)
                {
                    slots[i].selector.enabled = true;
                }
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void Update()
    {
        if(inventory.items.Count > 0)
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
        var d = Input.GetAxis("Mouse ScrollWheel");
        if(d != 0f)
        {
            // clear item selected
            for (int i = 0; i < inventory.space; i++)
            {
                slots[i].selector.enabled = false;
            }
        }
        if (d > 0f && inventory.items.Count > 0)
        {
            // scroll up
            itemSelected++;
            if (itemSelected == inventory.space + 1)
            {
                itemSelected = 1;
            }
            if (itemSelected <= inventory.items.Count)
            {
                Debug.Log("Item " + itemSelected + ": " + inventory.items[itemSelected - 1]);
            }
            else
            {
                Debug.Log("Item " + itemSelected);
            }
            // show selected item
            slots[itemSelected-1].selector.enabled = true;
        }
        else if (d < 0f && inventory.items.Count > 0)
        {
            // scroll down
            itemSelected--;
            if (itemSelected == 0)
            {
                itemSelected = inventory.space;
            }
            if (itemSelected <= inventory.items.Count)
            {
                Debug.Log("Item " + itemSelected + ": " + inventory.items[itemSelected - 1]);
            }
            else
            {
                Debug.Log("Item " + itemSelected);
            }
            // show selected item
            slots[itemSelected - 1].selector.enabled = true;
        }
    }
}
