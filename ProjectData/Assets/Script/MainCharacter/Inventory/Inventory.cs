
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> currentItems= new List<InventorySlot>();
    [SerializeField] public UnityEvent OnInventoryChanged;
    [SerializeField] private UnityEvent OnSelectedItemChanged;
    public int selectedItemId = 0;

    private void Start() 
    {
        OnSelectedItemChanged.Invoke();
    }
    
    public bool AddItems(InventoryItem newItem, int count = 1)
    {
        foreach ( InventorySlot InventorySlot in currentItems)
        {
            if(InventorySlot.item == null)
                continue;
            if(InventorySlot.item.id == newItem.id)
            {
                InventorySlot.count += count;
                OnInventoryChanged.Invoke();
                return true;
            }
        }
        foreach(InventorySlot InventorySlot in currentItems)
        {
            if(InventorySlot.item == null)
            {
                InventorySlot.item = newItem;
                InventorySlot.count = count;
                OnInventoryChanged.Invoke();
                return true;
            }
        }
        return false;
    }

    public Object RemoveSelectedItem()
    {
        Object removedObject;
        if(currentItems[selectedItemId].count > 1)
        {
            currentItems[selectedItemId].count--;
            removedObject = currentItems[selectedItemId].item.linketGameObject;
            return removedObject;
        }
        removedObject = currentItems[selectedItemId].item.linketGameObject;
        currentItems[selectedItemId].item = null;
        currentItems[selectedItemId].count = 0;
        OnInventoryChanged.Invoke();
        return removedObject;
    }  

    public InventoryItem GetItem(int i)
    {
        return i < currentItems.Count ? currentItems[i].item : null;
    }

    public int GetAmount(int i)
    {
        return i < currentItems.Count ? currentItems[i].count : 0;
    }

    public int GetSize()
    {
        return currentItems.Count;
    }

    public void ChangeSelectedItem(int direction)
    {
        selectedItemId += direction;
        selectedItemId = Mathf.Clamp(selectedItemId,0,GetSize() - 1);
        OnSelectedItemChanged.Invoke();
    }

    public InventoryItem GetSelectedItem()
    {
        return currentItems[selectedItemId].item;
    }

    public void DeleteSelectedItem()
    {
        currentItems[selectedItemId].item = null;
        OnInventoryChanged.Invoke();
    }
}

[System.Serializable]
public class InventorySlot
{
    public InventoryItem item;
    public int count;

    public InventorySlot(InventoryItem item, int count = 1)
    {
        this.item = item;
        this.count = count;
    }

}
