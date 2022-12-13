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

    private void Start()
    {
        chatUi.gameObject.SetActive(false);
        inventoryUi.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        chatUi.gameObject.SetActive(false);
        inventoryUi.gameObject.SetActive(false);
        mainMenuUi.gameObject.SetActive(true);
    }

    public void OpenChat()
    {
        Debug.Log("UIController: OpenChat");
        chatUi.gameObject.SetActive(true);
        mainMenuUi.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        inventoryUi.SetActive(true);
        mainMenuUi.SetActive(false);
    }
}
