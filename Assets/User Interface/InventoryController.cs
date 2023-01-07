using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryController : MonoBehaviour
{
    public UIController uiController;
    public GameObject inventoryDetailUi;
    public GameObject lochkarteRaetselUi;

    private VisualElement[] GetChildrenRecursive(VisualElement visualElement)
    {
        var result = new List<VisualElement>();
        foreach (var child in visualElement.Children())
        {
            result.Add(child);
            result.AddRange(GetChildrenRecursive(child));
        }
        return result.ToArray();
    }

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        var backButton = root.Q<Button>("BackButton");
        backButton.clicked += () =>
        {
            uiController.BackToMenu();
        };

        VisualElement inventoryElement = root.Q<VisualElement>("Elements");
        VisualElement[] inventoryElements = GetChildrenRecursive(inventoryElement);
        VisualElement[] inventoryItemContainers = inventoryElements
            .Where(x => x.ClassListContains("inventoryItemContainer"))
            .ToArray();

        StoredObject storedObject = DataPersistanceController.LoadData();
        var collectedObjects = storedObject.collectedObjects;

        foreach (VisualElement child in inventoryItemContainers)
        {
            bool found = collectedObjects.Contains(child.name);
            child.style.display = found ? DisplayStyle.Flex : DisplayStyle.None;

            if (!found)
                continue;

            Button inventoryItemButton = (Button)child;

            // check if Lochkarte and InteressantesPapier are found and open LochkarteRaetselUI instead of InventoryDetail
            if (
                (
                    collectedObjects.Contains("Lochkarte")
                    && collectedObjects.Contains("InteressantesPapier")
                )
                && (
                    inventoryItemButton.name.Equals("Lochkarte")
                    || inventoryItemButton.name.Equals("InteressantesPapier")
                )
            )
            {
                inventoryItemButton.clicked += () =>
                {
                    lochkarteRaetselUi.SetActive(true);
                };
            }
            else
            {
                inventoryItemButton.clicked += () =>
                {
                    StyleBackground styleBackground = null;
                    string itemLabel = "";

                    // The button has a VisualElement child that contains the actual image
                    foreach (VisualElement visualElement in child.Children())
                    {
                        if (visualElement.GetType() == typeof(Label))
                        {
                            itemLabel = ((Label)visualElement).text;
                        }
                        else
                        {
                            styleBackground = visualElement.resolvedStyle.backgroundImage;
                        }
                    }

                    inventoryDetailUi.SetActive(true);
                    inventoryDetailUi
                        .GetComponent<InventoryDetailController>()
                        .SetSprite(itemLabel, child.name, styleBackground);
                };
            }
        }

        // Check if all Bildschnipsel are collected and show FietesBesuch instead
        string[] partsToFind =
        {
            "Bildschnipsel1",
            "Bildschnipsel2",
            "Bildschnipsel3",
            "Bildschnipsel4",
            "Bildschnipsel5",
        };
        bool allPartsFound = partsToFind.All(x => collectedObjects.Contains(x));
        if (allPartsFound)
        {
            inventoryItemContainers.First(x => x.name == "Bildschnipsel1").style.display =
                DisplayStyle.None;
            inventoryItemContainers.First(x => x.name == "Bildschnipsel2").style.display =
                DisplayStyle.None;
            inventoryItemContainers.First(x => x.name == "Bildschnipsel3").style.display =
                DisplayStyle.None;
            inventoryItemContainers.First(x => x.name == "Bildschnipsel4").style.display =
                DisplayStyle.None;
            inventoryItemContainers.First(x => x.name == "Bildschnipsel5").style.display =
                DisplayStyle.None;
            inventoryItemContainers.First(x => x.name == "FietesBesuch").style.display =
                DisplayStyle.Flex;
        }
    }
}
