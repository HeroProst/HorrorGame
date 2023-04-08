using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> icons = new List<Image>();
    [SerializeField] private List<Image> backgroundImage = new List<Image>();

    public void UpdateUI(Inventory inventory)
    {
        for(int i = 0; i < inventory.GetSize() && i < icons.Count;i++)
        if(inventory.GetItem(i) != null)
        {
            icons[i].color = new Color(icons[i].color.r,icons[i].color.g,icons[i].color.b,1f);
            icons[i].sprite = inventory.GetItem(i).Icon;
        }
        else
        {
            icons[i].sprite = null;
            icons[i].color = new Color(icons[i].color.r,icons[i].color.g,icons[i].color.b,0f);
        }

    }

    public void ChangeSelectedItemBackground(Inventory inventory)
    {
        foreach(Image image in backgroundImage)
        {
            image.color = new Color(1,1,1,1);
        }
        backgroundImage[inventory.selectedItemId].color = new Color(1f,0.9453999f,0.7311321f,1f);
    }
}
