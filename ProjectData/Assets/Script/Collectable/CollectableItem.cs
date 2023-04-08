using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private InventoryItem linketInventoryItem;
    [SerializeField] private int count = 1;
    [SerializeField] public UnityEvent OnItemPickUp;
    [SerializeField] public AudioSource CharacterInteractionSound;

    public void CollectGameObject(Inventory characterInventory) {
        if(!linketInventoryItem) return;

        if(characterInventory)
        {
            if(characterInventory.AddItems(linketInventoryItem, count))
            {
                OnItemPickUp.Invoke();
                Destroy(gameObject);
            }
            else
                return;
        }
    }

    public void PlaySound(AudioClip sound)
    {
        if(CharacterInteractionSound == null)
            return;
        CharacterInteractionSound.clip = sound;
        CharacterInteractionSound.Play();
    }

    public void SetCharacterInteractionSound(AudioSource source)
    {
        CharacterInteractionSound = source;
    }
}
