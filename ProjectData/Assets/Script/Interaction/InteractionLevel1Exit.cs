using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionLevel1Exit : InteractionBase
{
    private bool lock1,lock2,lock3,lock4 = false;

    public override bool Interact(InventoryItem currentItem)
    {
        if(currentItem != null)
        {
            switch (currentItem.Name)
            {
                case "Level1_key1":
                {
                    lock1 = true;
                    break;
                }
                case "Level1_key2":
                {
                    lock2 = true;
                    break;
                }
                case "Level1_key3":
                {
                    lock3 = true;
                    break;
                }
                case "Level1_key4":
                {
                    lock4 = true;
                    break;
                }
            }
            OnInteraction.Invoke();
        }
        if(lock1 && lock2 && lock3 && lock4)
            SceneManager.LoadScene("TheEnd");
        return true;
    }
}
