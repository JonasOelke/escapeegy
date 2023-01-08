using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.IO;

public class ChatController : MonoBehaviour
{
    ScrollView chatMessagesContainer;
    VisualElement messageSuggestionsContainer;
    public Messages messagesScript;
    public Items itemsScript;
    private ChatMessage[] _messages;
    private Item[] _items;
    private bool firstOpened = true;
    StoredObject storedObject;
    private bool firstStart;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Chatcontroller");
        _messages = messagesScript.GetChatMessages();
        _items = itemsScript.getItems();
        //Sektion für stored Object bei Start
        try
        {
            storedObject = DataPersistanceController.LoadData();
            // LoadScore(storedObject);
        }
        catch (FileNotFoundException e)
        {
            StoredObject storedObject = new StoredObject(new List<string>());
            DataPersistanceController.PersistData(storedObject);
            SceneManager.LoadScene("UniMap");
        }

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        chatMessagesContainer = root.Q<ScrollView>("ChatMessagesContainer");
        messageSuggestionsContainer = root.Q<VisualElement>("MessageSuggestionsContainer");
        var backButton = root.Q<Button>("BackButton");
        backButton.clicked += () =>
        {
            GetComponentInParent<UIController>().BackToMenu();
        };

        ClearChat();
        firstStart = true;
        AddMessagetoSuggestionsContainer(1); //------------------------------------------------------------------------------evtl ungut
        OnEnable();
    }

    IEnumerator Wait(Action Callback)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 1 second.
        yield return new WaitForSeconds(2);
        Callback();
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    private void OnEnable()
    {
        Debug.Log("Enable");
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        chatMessagesContainer = root.Q<ScrollView>("ChatMessagesContainer");
        messageSuggestionsContainer = root.Q<VisualElement>("MessageSuggestionsContainer");
        var backButton = root.Q<Button>("BackButton");

        //Sektion für stored Object bei Start
        try
        {
            storedObject = DataPersistanceController.LoadData();
            LoadChatHistory(storedObject, firstOpened);
            Debug.Log(storedObject + " Wurde gefunden, aber wieso");
        }
        catch (FileNotFoundException e)
        {
            StoredObject storedObject = new StoredObject(new List<string>());
            DataPersistanceController.PersistData(storedObject);
            SceneManager.LoadScene("Intro_Slides1");
        }

        Debug.Log("BBBBBBBBBBBBBBBB" + storedObject);
        backButton.clicked += () =>
        {
            GetComponentInParent<UIController>().BackToMenu();
        };

        if (storedObject.firstOpened)
        {
            Debug.Log("DDDDDDDDDDDDDDDDDD");
            storedObject.setOpened(false);
            DataPersistanceController.PersistData(storedObject);
        }
    }

    void ClearChat()
    {
        Debug.Log("Clearing Chat");
        var children = new List<VisualElement>();
        foreach (var visualElement in chatMessagesContainer.Children())
        {
            children.Add(visualElement);
        }
        children.ForEach(child => chatMessagesContainer.Remove(child));

        children = new List<VisualElement>();
        foreach (var visualElement in messageSuggestionsContainer.Children())
        {
            children.Add(visualElement);
        }
        children.ForEach(child => messageSuggestionsContainer.Remove(child));
    }

    //Funktion um den Chat an gefundene Objekte anzupassen
    public void ChatToStoryLogic(string name)
    {
        if (name == "MaggiesTagebucheintrag1")
        {
            AddMessagetoSuggestionsContainer(5);
        }
        else if (name == "MaggiesTagebucheintrag2")
        {
            AddMessagetoSuggestionsContainer(13);
        }
        else if (name == "Verlaufsbericht")
        {
            AddMessagetoSuggestionsContainer(31);
        }
        else if (name == "MaggiesTagebucheintrag4")
        {
            AddMessagetoSuggestionsContainer(47);
        }
        else if (name == "universalHelp")
        {
            AddMessagetoSuggestionsContainer(63);
        }
    }

    public void AddToChatMessagesContainer(ChatMessage chatMessage, bool reLoading)
    {
        StateControl.AddWrittenMessage(chatMessage);

        // Takes ChatMassage-Object and puts it into sent Chat Box ("sends it")
        // Using ChatMessagesContainer in UI
        // Searches for noted answer and sets it into Chat Box too
        // Uses next void to display all new suggestions (for for IDs)
        // For (chatResponse in chatressponses){
        //      chatMessagesContainer.append(chatResponse.getMessage());
        // }



        if (chatMessage.text != "")
        {
            VisualElement msgContainer = new VisualElement();
            msgContainer.AddToClassList("chatMessageContainer");

            Label msg = new Label(chatMessage.text);
            msg.AddToClassList("chatMessageRight");

            msgContainer.Add(msg);
            chatMessagesContainer.Add(msgContainer);
        }
        else if (chatMessage.photo)
        {
            VisualElement msg = new VisualElement();
            msg.AddToClassList("chatMessageRight");
            msg.AddToClassList("chatMessagePhoto");
            msg.style.backgroundImage = new StyleBackground(chatMessage.photo);

            // get the image aspect ratio, and set the height based on the actual width of the container
            msg.style.height = (float)(
                chatMessage.photo.rect.height / chatMessage.photo.rect.width * Screen.width * 0.8
            );
            chatMessagesContainer.Add(msg);
        }

        foreach (ChatResponse chatResponse in chatMessage.responses)
        {
            if (chatResponse.text != "NEE")
            {
                VisualElement responseContainer = new VisualElement();
                responseContainer.AddToClassList("chatMessageContainer");
                if (chatResponse.text != "")
                {
                    Label response = new Label(chatResponse.text);
                    response.AddToClassList("chatMessageLeft");
                    responseContainer.Add(response);
                }
                else if (chatResponse.photo)
                {
                    VisualElement response = new VisualElement();
                    response.AddToClassList("chatMessageLeft");
                    response.AddToClassList("chatMessagePhoto");
                    response.style.backgroundImage = new StyleBackground(chatResponse.photo);

                    // get the image aspect ratio, and set the height based on the actual width of the container
                    response.style.height = (float)(
                        chatResponse.photo.rect.height
                        / chatResponse.photo.rect.width
                        * Screen.width
                        * 0.8
                    );

                    responseContainer.Add(response);
                }
                if (reLoading)
                {
                    chatMessagesContainer.Add(responseContainer);
                }
                else
                {
                    StartCoroutine(Wait(() => chatMessagesContainer.Add(responseContainer)));
                }
            }
        }

        if (reLoading)
        {
            AddMessageToContainerAndSetNextSuggestion(chatMessage);
        }
        else
        {
            StartCoroutine(Wait(() => AddMessageToContainerAndSetNextSuggestion(chatMessage)));
        }
    }

    void AddMessageToContainerAndSetNextSuggestion(ChatMessage chatMessage)
    {
        Debug.Log("AddMessageToContainerAndSetNextSuggestion");
        foreach (int nextSuggestion in chatMessage.nextIds)
        {
            if (nextSuggestion != 0)
            {
                AddMessagetoSuggestionsContainer(nextSuggestion);
            }
        }
    }

    void AddMessagetoSuggestionsContainer(int id)
    {
        // Searches for new suggestion with noted ID
        // Puts the text into suggestionBox

        var chatMessage = Array.Find(_messages, e => e.id == id);
        Button messageSuggestion = new Button();
        if (chatMessage.summary == "")
        {
            messageSuggestion.text = chatMessage.text;
        }
        else
        {
            messageSuggestion.text = chatMessage.summary;
        }
        messageSuggestion.AddToClassList("chatSuggestion");
        messageSuggestion.clicked += () =>
        {
            AddToChatMessagesContainer(chatMessage, false);
            messageSuggestion.parent.Remove(messageSuggestion);
        };
        messageSuggestionsContainer.Add(messageSuggestion);
    }

    void LoadChatHistory(StoredObject myObject, bool reLoading)
    {
        //TODO: hier aus dem storedObject den state int rausziehen und dann an den GameControll übergeben-----------------------------------------------------------------------------------------------------
        // FunktionUmEsInGameControl(myObject.state)

        foreach (ChatMessage sentMessage in myObject.sentMessages)
        {
            AddToChatMessagesContainer(sentMessage, reLoading);
        }
    }
}
