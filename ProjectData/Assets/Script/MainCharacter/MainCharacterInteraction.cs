using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterInteraction : MonoBehaviour
{
    [SerializeField] private Camera CharacterCamera;
    [SerializeField] private Rigidbody mainCharacterRigitBody;
    [SerializeField] private Collider DropBox;
    [SerializeField] private CharacterRayCast rayCast;
    [SerializeField] private Inventory inventory;
    [SerializeField] MeinMenuScrip InGameMenu;

    public void DropSelectedItem(Object inventoryItem)
    {
        Vector3 dropBoxPos = DropBox.transform.position;
        Vector3 newObjectPos = new Vector3(dropBoxPos.x,dropBoxPos.y,dropBoxPos.z);
        Instantiate(inventoryItem,newObjectPos,CharacterCamera.transform.rotation);        
    }

    public void TypeOfInteraction()
    {
        PickUpGameObject();
        InteractGameObject();
    }

    private void PickUpGameObject()
    {
        RaycastHit hit = rayCast.CastRay();
        if(hit.collider == null)
            return;
        if(!hit.collider.gameObject.GetComponent<CollectableItem>())
            return;
        hit.collider.gameObject.GetComponent<CollectableItem>().CollectGameObject(inventory);
    }

    private void InteractGameObject()
    {
        RaycastHit hit = rayCast.CastRay();
        if(hit.collider == null)
            return;
        if(!hit.collider.gameObject.GetComponent<InteractionBase>())
            return;
        if(hit.collider.gameObject.GetComponent<InteractionBase>().Interact(inventory.GetSelectedItem()))
        {
            inventory.DeleteSelectedItem();
        }
    }

    public void CallInGameMenu()
    {
        InGameMenu.CallMenu();
    }
}
