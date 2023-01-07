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
        addMessagetoSuggestionsContainer(1); //------------------------------------------------------------------------------evtl ungut
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
            LoadScore(storedObject, firstOpened);
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

    public void AddToChatMessagesContainer(ChatMessage chatMessage, bool reLoading)
    {
        //Storing stuff
        Debug.Log("AddtoChatMessagesContainer" + chatMessage.id);
        StateControl.AddWrittenMessage(chatMessage.id);
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
            Debug.Log("Text der NAchricht_" + chatMessage.text);
            msg.AddToClassList("chatMessageRight");

            msgContainer.Add(msg);
            Debug.Log("Adding message");
            chatMessagesContainer.Add(msgContainer);
        }
        else if (chatMessage.photo)
        {
            VisualElement msg = new VisualElement();
            Debug.Log("Sprite: " + chatMessage.photo.name);
            msg.AddToClassList("chatMessageRight");
            msg.AddToClassList("chatMessageRightPhoto");
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
                Debug.Log("Adding RESPONSE");
                VisualElement responseContainer = new VisualElement();
                responseContainer.AddToClassList("chatMessageContainer");
                if (chatResponse.photo == "")
                {
                    Label response = new Label(chatResponse.text);
                    response.AddToClassList("chatMessageLeft");
                    responseContainer.Add(response);
                }
                else
                {
                    Label response = new Label(chatResponse.text);
                    switch (chatResponse.photo)
                    {
                        case "Lochkarte":
                            response.AddToClassList("emmasFirstPic");
                            break;
                        case "Tagebucheintrag25.April":
                            response.AddToClassList("emmasSecondPic");
                            break;
                        case "Tagebucheintrag26.Dezember":
                            response.AddToClassList("emmasThirdPic");
                            break;
                        case "decryptedLetter":
                            response.AddToClassList("emmasFourthPic");
                            break;
                        case "Tagebucheintrag10.Mai":
                            response.AddToClassList("emmasFifthPic");
                            break;
                    }

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
            Debug.Log("Delay starts");
            StartCoroutine(Wait(() => AddMessageToContainerAndSetNextSuggestion(chatMessage)));
            Debug.Log("Delay ends");
        }
    }

    void AddMessageToContainerAndSetNextSuggestion(ChatMessage chatMessage)
    {
        Debug.Log("AddMessageToContainerAndSetNextSuggestion");
        foreach (int nextSuggestion in chatMessage.nextIds)
        {
            if (nextSuggestion != 0)
            {
                addMessagetoSuggestionsContainer(nextSuggestion);
            }
        }
    }

    void addMessagetoSuggestionsContainer(int id)
    {
        Debug.Log("addMessagetoSuggestionsContainer");
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

    void LoadScore(StoredObject myObject, bool reLoading)
    {
        Debug.Log("Loading Score, reloading:" + reLoading);
        foreach (var chatMessageID in myObject.sentMessages)
        {
            //  Debug.Log("Gesendete Nachricht: "+ chatMessageID);
            if (chatMessageID < 100)
            {
                foreach (ChatMessage chatMessage in _messages)
                {
                    if (chatMessage.id == chatMessageID)
                    {
                        // Debug.Log("Gesendete Nachricht: "+ chatMessageID);
                        AddToChatMessagesContainer(chatMessage, reLoading);
                    }
                }
            }
            else
            {
                //Wenn id >100 ist es keine Message, sondern ein bild. Dann muss auf das zugehörige Item zugegriffen werden und die Responses da rausgesucht werden
                foreach (Item item in _items)
                {
                    //Item aus Item Array raussuchen
                    if (item.id == chatMessageID)
                    {
                        //Und die Message zum Container hinzufügen
                        VisualElement responseContainer = new VisualElement();
                        responseContainer.AddToClassList("chatMessageContainer");
                        Label response = new Label(item.response);
                        response.AddToClassList("chatMessageLeft");
                        responseContainer.Add(response);
                        chatMessagesContainer.Add(responseContainer);
                    }
                }
            }
        }

        foreach (string name in myObject.collectedObjects)
        {
            //Hier in inventar laden
        }
    }
}
