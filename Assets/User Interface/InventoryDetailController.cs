using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryDetailController : MonoBehaviour
{
    private VisualElement root;
    public ChatController chatController;
    public GameObject popupDialog;

    void OnEnable()
    {
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
                Debug.Log("Mit Tante Emma Teilen");
            };
            dialogProperties.dialogButtonRightAction = () => popupDialog.SetActive(false);
            popupDialog.SetActive(true);
            popupDialog.GetComponent<PopupDialogController>().SetDialogProperties(dialogProperties);
        };
    }

    public void SetSprite(string label, StyleBackground texture2D)
    {
        VisualElement image = root.Q<VisualElement>("Image");
        image.style.backgroundColor = new StyleColor(new Color(1f, 1f, 1f, 0f));
        image.style.backgroundImage = Background.FromSprite(texture2D.value.sprite);

        Label title = root.Q<Label>("Title");
        title.text = label;
    }
}
