using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryDetailController : MonoBehaviour
{
    private VisualElement root;
    private ChatController chatController;
    public GameObject popupDialog;
    public GameObject chatUi;
    public UIController uiController;
    private Sprite _sprite;
    private string _inventoryItemName;

    void OnEnable()
    {
        chatController = chatUi.GetComponent<ChatController>();
        root = GetComponent<UIDocument>().rootVisualElement;
        Button button = root.Q<Button>("BackButton");
        button.clicked += () =>
        {
            gameObject.SetActive(false);
        };

        Button sharebutton = root.Q<Button>("ShareButton");
        sharebutton.clicked += () =>
        {
            PopupDialogController.DialogProperties dialogProperties =
                new PopupDialogController.DialogProperties();
            dialogProperties.dialogTitle = "Teilen";
            dialogProperties.dialogMessage = "Möchtest du das Element mit Tante Emma teilen?";
            dialogProperties.dialogButtonLeftText = "Ja";
            dialogProperties.dialogButtonRightText = "Nein";
            dialogProperties.dialogButtonLeftAction = () =>
            {
                Messages messagesClass = chatUi.GetComponent<Messages>();
                ChatMessage[] chatMessages = messagesClass.GetChatMessages();

                ChatMessage chatMessage;
                try
                {
                    chatMessage = chatMessages[InventoryItemToMessageIdMap.Map[_inventoryItemName]];
                }
                catch (Exception e)
                {
                    chatMessage = chatMessages[61];
                }

                chatMessage.photo = _sprite;
                uiController.OpenChat();
                chatController.AddToChatMessagesContainer(chatMessage, false);
            };
            dialogProperties.dialogButtonRightAction = () => popupDialog.SetActive(false);
            popupDialog.SetActive(true);
            popupDialog.GetComponent<PopupDialogController>().SetDialogProperties(dialogProperties);
        };
    }

    public void SetSprite(string label, string inventoryItemName, StyleBackground texture2D)
    {
        VisualElement image = root.Q<VisualElement>("Image");
        _sprite = texture2D.value.sprite;
        _inventoryItemName = inventoryItemName;

        Debug.Log("InventoryItemName: " + _inventoryItemName);

        image.style.backgroundColor = new StyleColor(new Color(1f, 1f, 1f, 0f));
        image.style.backgroundImage = Background.FromSprite(_sprite);

        Label title = root.Q<Label>("Title");
        title.text = label;
    }
}
