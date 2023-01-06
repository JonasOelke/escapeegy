using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public UIController UIController;
    private Button _inventoryButton;
    private Button _chatButton;
    public GameObject minimapCanvas;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button inventoryButton = root.Q<Button>("InventoryButton");
        Button chatButton = root.Q<Button>("ChatButton");
        Button floorButton = root.Q<Button>("FloorButton");
        Button mapButton = root.Q<Button>("MapButton");
        
        VisualElement floorMenu = root.Q<VisualElement>("FloorMenu");
        floorMenu.style.display = DisplayStyle.None;

        inventoryButton.clicked += () =>
        {
            UIController.OpenInventory();
        };

        mapButton.clicked += () =>
        {
            minimapCanvas.SetActive(!minimapCanvas.activeSelf);
        };

        chatButton.clicked += () =>
        {
            UIController.OpenChat();
        };

        floorButton.clicked += () =>
        {
            floorMenu.style.display =
                floorMenu.style.display == DisplayStyle.Flex
                    ? DisplayStyle.None
                    : DisplayStyle.Flex;
        };

        Button atticButton = root.Q<Button>("AtticButton");
        Button secondFloorButton = root.Q<Button>("SecondFloorButton");
        Button groundFloorButton = root.Q<Button>("GroundFloorButton");

        atticButton.clicked += () =>
        {
            Debug.Log("Move Player to Attic");
        };

        secondFloorButton.clicked += () =>
        {
            Debug.Log("Move Player to Second Floor");
        };

        groundFloorButton.clicked += () =>
        {
            Debug.Log("Move Player to Ground Floor");
        };
    }
}
