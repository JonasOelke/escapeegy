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
    VisualElement root;
    public GameObject minimapCanvas;
    public GameObject qrCodeOverlayUI;

    // This variable is to indicate if the MainMenu has been opened before in the session or not
    // this is important to determine, if the initial QR code scan should be shown or not
    public bool hasNotBeenOpenedBefore = true;

    public void SetDisplayCollectedButton(bool onOrOff)
    {
        VisualElement button = root.Q<VisualElement>("CollectButtonContainer");
        button.style.display = onOrOff ? DisplayStyle.Flex : DisplayStyle.None;
    }

    public void SetCollectedButtonAction(Action action)
    {
        Button button = root.Q<Button>("CollectButton");
        button.clicked += action;
        button.clicked += () =>
        {
            SetDisplayCollectedButton(false);
        };
    }

    public void SetResetButtonAction()
    {
        Button button2 = root.Q<Button>("ResetButton");
        button2.clicked += () =>
        {
            DataPersistanceController.DeleteData();
        };
    }

    public void SetQrCodeOverlay(bool value)
    {
        qrCodeOverlayUI.SetActive(value);
    }

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Button resetButton = root.Q<Button>("ResetButton");
        Button inventoryButton = root.Q<Button>("InventoryButton");
        Button chatButton = root.Q<Button>("ChatButton");
        Button floorButton = root.Q<Button>("FloorButton");
        string currentFloor = "EG";
        Button mapButton = root.Q<Button>("MapButton");

        Button qrCodeButton = root.Q<Button>("QrCodeButton");
        qrCodeButton.clicked += () =>
        {
            SetQrCodeOverlay(!qrCodeOverlayUI.activeSelf);
            if (qrCodeOverlayUI.activeSelf)
            {
                GameObject
                    .Find("QrCodeOverlayUI")
                    .GetComponent<UIDocument>()
                    .rootVisualElement.Q<Label>("Title")
                    .text = "";
                if (minimapCanvas.activeSelf)
                {
                    minimapCanvas.SetActive(!minimapCanvas.activeSelf);
                }
                GameObject.Find("QRCodeRecenter").GetComponent<QRCodeRecenter>().ToggleScanning();
            }
        };

        if (hasNotBeenOpenedBefore)
        {
            qrCodeOverlayUI.SetActive(true);
            GameObject.Find("QRCodeRecenter").GetComponent<QRCodeRecenter>().ToggleScanning();
            hasNotBeenOpenedBefore = false;
        }

        VisualElement floorMenu = root.Q<VisualElement>("FloorMenu");
        floorMenu.style.display = DisplayStyle.None;

        // Show the minimap button only if the Grundgriss Object was collected
        StoredObject storedObject = DataPersistanceController.LoadData();
        var collectedObjects = storedObject.collectedObjects;
        VisualElement mapButtonContainer = root.Q<VisualElement>("MapButtonContainer");
        mapButtonContainer.style.display = collectedObjects.Contains("Grundriss")
            ? DisplayStyle.Flex
            : DisplayStyle.None;

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

        resetButton.clicked += () =>
        {
            DataPersistanceController.DeleteData();
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
            GetComponent<ChangeFloor>().FloorChange(currentFloor, "DG");
            currentFloor = "DG";
            Debug.Log(currentFloor);
        };

        secondFloorButton.clicked += () =>
        {
            GetComponent<ChangeFloor>().FloorChange(currentFloor, "2OG");
            currentFloor = "2OG";
            Debug.Log(currentFloor);
        };

        groundFloorButton.clicked += () =>
        {
            GetComponent<ChangeFloor>().FloorChange(currentFloor, "EG");
            currentFloor = "EG";
            Debug.Log(currentFloor);
        };
    }
}
