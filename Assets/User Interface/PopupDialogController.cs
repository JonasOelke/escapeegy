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

    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    public class DialogProperties
    {
        public string DialogTitle;
        public string DialogMessage;
        public string DialogButtonLeftText;
        public string DialogButtonRightText;
        public Action DialogButtonLeftAction;
        public Action DialogButtonRightAction;
    }

    public void SetDialogProperties(DialogProperties dialogProperties)
    {
        Label dialogTitle = root.Q<Label>("Title");
        Label dialogMessage = root.Q<Label>("Message");
        Button dialogButtonLeft = root.Q<Button>("ButtonLeft");
        Button dialogButtonRight = root.Q<Button>("ButtonRight");

        dialogButtonLeft.clicked += () => dialogProperties.DialogButtonLeftAction();
        dialogButtonRight.clicked += () => dialogProperties.DialogButtonRightAction();

        dialogButtonLeft.text = dialogProperties.DialogButtonLeftText;
        dialogButtonRight.text = dialogProperties.DialogButtonRightText;

        dialogTitle.text = dialogProperties.DialogTitle;
        dialogMessage.text = dialogProperties.DialogMessage;
    }
}
