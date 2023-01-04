using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupDialogController : MonoBehaviour
{
    private string DialogTitle;
    private string DialogMessage;
    private string DialogButtonLeftText;
    private string DialogButtonRightText;
    private Action DialogButtonLeftAction;
    private Action DialogButtonRightAction;

    private VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    public class DialogProperties
    {
        public string dialogTitle;
        public string dialogMessage;
        public string dialogButtonLeftText;
        public string dialogButtonRightText;
        public Action dialogButtonLeftAction;
        public Action dialogButtonRightAction;
    }

    public void SetDialogProperties(DialogProperties dialogProperties)
    {
        Label dialogTitle = root.Q<Label>("Title");
        Label dialogMessage = root.Q<Label>("Message");
        Button dialogButtonLeft = root.Q<Button>("ButtonLeft");
        Button dialogButtonRight = root.Q<Button>("ButtonRight");

        dialogButtonLeft.clicked += () => dialogProperties.dialogButtonLeftAction();
        dialogButtonRight.clicked += () => dialogProperties.dialogButtonRightAction();

        dialogButtonLeft.text = dialogProperties.dialogButtonLeftText;
        dialogButtonRight.text = dialogProperties.dialogButtonRightText;

        dialogTitle.text = dialogProperties.dialogTitle;
        dialogMessage.text = dialogProperties.dialogMessage;
    }
}
