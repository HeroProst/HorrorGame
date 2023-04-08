using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionLevel1Door : InteractionBase
{
    bool isOpened = false;
    Vector3 cloasedAngel = new Vector3(0,90,0);
    Vector3 openedAngle = new Vector3(0,180,0);

    public override bool Interact(InventoryItem currentItem)
    {
        if(isOpened)
            this.transform.rotation = Quaternion.Euler(cloasedAngel);
        else
            this.transform.rotation = Quaternion.Euler(openedAngle);
        isOpened = !isOpened;
        OnInteraction.Invoke();
        return false;
    }
}

