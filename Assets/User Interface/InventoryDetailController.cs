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

        Dictionary<string, int> inventoryItemToMessageIdMap = new Dictionary<string, int>();
        inventoryItemToMessageIdMap.Add("ElliesBrief1", 15);

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
                ChatMessage chatMessage = chatMessages[
                    inventoryItemToMessageIdMap[_inventoryItemName]
                ];
                chatMessage.photo = _sprite;
                chatMessage.text = "Ich möchte gerne ein Item aus meinem Inventar mit dir teilen!";
                uiController.OpenChat();
                chatController.AddToChatMessagesContainer(chatMessage);
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

        image.style.backgroundColor = new StyleColor(new Color(1f, 1f, 1f, 0f));
        image.style.backgroundImage = Background.FromSprite(_sprite);

        Label title = root.Q<Label>("Title");
        title.text = label;
    }
}
