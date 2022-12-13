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

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button inventoryButton = root.Q<Button>("InventoryButton");
        Button chatButton = root.Q<Button>("ChatButton");

        inventoryButton.clicked += () =>
        {
            UIController.OpenInventory();
        };

        chatButton.clicked += () =>
        {
            UIController.OpenChat();
        };
    }
}
