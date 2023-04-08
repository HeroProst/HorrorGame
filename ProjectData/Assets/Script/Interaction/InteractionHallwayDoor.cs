using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionHallwayDoor : InteractionBase
{
    public override bool Interact(InventoryItem currentItem)
    {
        SceneManager.LoadScene("Level1");
        return false;
    }
}
