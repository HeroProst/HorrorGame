using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject 
{
    public int id;
    public string Name = "Item";
    public Sprite Icon;
    public Object linketGameObject;
}
