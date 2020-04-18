using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than on instance of Inventory found!");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 4;
    private int itemSelected = 1;

    public List<Item> items = new List<Item>();  

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);
        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    void Update()
    {
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            // scroll up
            itemSelected++;
            if(itemSelected == space + 1)
            {
                itemSelected = 1;
            }
            if (itemSelected <= items.Count)
            {
                Debug.Log("Item " + itemSelected + ": " + items[itemSelected-1]);
            } else
            {
                Debug.Log("Item " + itemSelected);
            }
            
        }
        else if (d < 0f)
        {
            // scroll down
            itemSelected--;
            if (itemSelected == 0)
            {
                itemSelected = space;
            }
            if (itemSelected <= items.Count)
            {
                Debug.Log("Item " + itemSelected + ": " + items[itemSelected-1]);
            }
            else
            {
                Debug.Log("Item " + itemSelected);
            }
        }
    }
}
