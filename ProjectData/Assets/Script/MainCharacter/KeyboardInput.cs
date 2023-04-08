using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private Inventory inventory;
    [SerializeField] private MainCharacterInteraction interaction;
    public float radius = 10f;

    private void Update()
    {
        if(Time.timeScale == 1)
        {
            SprintChecker();
            CharacterMoveChecker();
            DropItemChecker();
            SwitchInventoryItem();
            InteractionChecker();
            InGameMenuCaller();
        }
        else
            _movement.moveSound.Stop();
    }

    private void SprintChecker()
    {
        float sprint = Input.GetAxisRaw("Sprint");
        _movement.sprintSpeedChanger(sprint);
    }

    private void CharacterMoveChecker()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float angle = transform.rotation.eulerAngles.y;
        float radian = angle * Mathf.PI/180;
        float x = radius * Mathf.Sin(radian);
        float y = radius * Mathf.Cos(radian);
        _movement.Move(new Vector3(-vertical * y + horizontal * x, 0, vertical * x + horizontal * y ));
    }

    private void DropItemChecker()
    {
        if(inventory.GetItem(inventory.selectedItemId) == null)
            return;
        if(Input.GetButtonDown("DropItem"))
            interaction.DropSelectedItem(inventory.RemoveSelectedItem());
    }

    private void InteractionChecker()
    {
        if(!Input.GetButtonDown("GameObjectInteraction"))
            return;
        interaction.TypeOfInteraction();
    }

    private void SwitchInventoryItem()
    {
        if(Input.GetButtonDown("IncInventoryItem"))
            inventory.ChangeSelectedItem(1);
        else if(Input.GetButtonDown("DecInventoryItem"))
            inventory.ChangeSelectedItem(-1);
    }

    private void InGameMenuCaller()
    {
        if(!Input.GetButtonDown("InGameMenuCall"))
            return;
        interaction.CallInGameMenu();
    }
}
