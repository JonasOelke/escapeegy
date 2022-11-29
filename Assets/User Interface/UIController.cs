using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public GameObject chatUi;
    public GameObject mainMenuUi;
    public GameObject inventoryUi;

    private void OnEnable()
    {
        VisualElement root = GameObject
            .Find("MainMenuUI")
            .GetComponent<UIDocument>()
            .rootVisualElement;

        Button inventoryButton = root.Q<Button>("InventoryButton");
        Button chatButton = root.Q<Button>("ChatButton");

        inventoryButton.clicked += () =>
        {
            inventoryUi.SetActive(true);
            mainMenuUi.SetActive(false);
        };

        chatButton.clicked += () =>
        {
            chatUi.gameObject.SetActive(true);
            mainMenuUi.gameObject.SetActive(false);
        };

        chatUi.gameObject.SetActive(false);
        inventoryUi.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        chatUi.gameObject.SetActive(false);
        inventoryUi.gameObject.SetActive(false);
        mainMenuUi.gameObject.SetActive(true);
    }
}
