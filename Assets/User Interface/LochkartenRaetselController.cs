using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LochkartenRaetselController : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button backButton = root.Q<Button>("BackButton");
        Slider lochkarteSlider = root.Q<Slider>("LochkarteSlider");
        VisualElement lochkarte = root.Q<VisualElement>("Lochkarte");
         backButton.clicked += () =>
        {
            gameObject.SetActive(false);
        };
        lochkarteSlider.RegisterValueChangedCallback(
            (e) =>
            {
                lochkarte.style.right = -lochkarteSlider.value;
            }
        );
        
        Slider interessantesPapierSlider = root.Q<Slider>("InteressantesPapierSlider");
        VisualElement interessantesPapier = root.Q<VisualElement>("InteressantesPapier");
        interessantesPapierSlider.RegisterValueChangedCallback(
            (e) =>
            {
                interessantesPapier.style.right = -interessantesPapierSlider.value;
            }
        );
    }
}
