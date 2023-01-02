using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryDetailController : MonoBehaviour
{
    private VisualElement root;
    public ChatController chatController;

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
            Debug.Log("Share");
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
