using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryController : MonoBehaviour
{
    public UIController uiController;
    public GameObject inventoryDetailUi;

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

        foreach (
            VisualElement child in inventoryElements.Where(
                x => x.ClassListContains("inventoryItemContainer")
            )
        )
        {
            StoredObject storedObject = DataPersistanceController.LoadData();
            var collectedObjects = storedObject.collectedObjects;

            bool found = collectedObjects.Contains(child.name);
            child.style.display = found ? DisplayStyle.Flex : DisplayStyle.None;

            if (!found)
                continue;

            Button inventoryItemButton = (Button)child;
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
                    .SetSprite(itemLabel, styleBackground);
            };
        }
    }
}
