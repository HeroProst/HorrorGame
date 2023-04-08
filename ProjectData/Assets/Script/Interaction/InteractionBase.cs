using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionBase : MonoBehaviour
{
    [SerializeField] public AudioSource CharacterInteractionSound;
    [SerializeField] public UnityEvent OnInteraction;
    
    public virtual bool Interact(InventoryItem currentItem) {return false;   }

    public void InteractionSound(AudioClip interactionSound)
    {
        CharacterInteractionSound.clip = interactionSound;
        CharacterInteractionSound.Play();
    }
}
