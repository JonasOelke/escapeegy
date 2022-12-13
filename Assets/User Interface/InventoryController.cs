using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryController : MonoBehaviour
{
    public UIController uiController;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        var backButton = root.Q<Button>("BackButton");
        backButton.clicked += () =>
        {
            Debug.Log("InventoryController: Back button clicked");
            uiController.BackToMenu();
        };
    }
}
