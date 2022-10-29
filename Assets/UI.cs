using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button inventoryButton = root.Q<Button>("InventoryButton");
        VisualElement inventoryContainer = root.Q<VisualElement>("InventoryContainer");

        Button chatButton = root.Q<Button>("ChatButton");
        VisualElement chatContainer = root.Q<VisualElement>("ChatContainer");

        //Disable the inventory and chat containers, just in case someone forgot to do it in the editor
        inventoryContainer.style.display = DisplayStyle.None;
        chatContainer.style.display = DisplayStyle.None;

        Button suggestion1 = root.Q<Button>("Suggestion1");
        Button suggestion2 = root.Q<Button>("Suggestion2");
        ScrollView chatMessagesContainer = root.Q<ScrollView>("ChatMessagesContainer");

        inventoryButton.clicked += () =>
        {
            chatContainer.style.display = DisplayStyle.None;
            inventoryContainer.style.display =
                inventoryContainer.style.display == DisplayStyle.Flex
                    ? DisplayStyle.None
                    : DisplayStyle.Flex;
        };

        chatButton.clicked += () =>
        {
            chatContainer.style.display =
                chatContainer.style.display == DisplayStyle.Flex
                    ? DisplayStyle.None
                    : DisplayStyle.Flex;
            inventoryContainer.style.display = DisplayStyle.None;
        };

        suggestion1.clicked += () =>
        {
            VisualElement msgContainer = new VisualElement();
            msgContainer.AddToClassList("chatMessageContainer");
            Label msg = new Label("Hast du noch einen\nHinweis für mich?");
            msg.AddToClassList("chatMessage");
            msgContainer.Add(msg);

            chatMessagesContainer.Add(msgContainer);
            suggestion1.text = "nix";
        };
    }
}
