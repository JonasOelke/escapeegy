using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChatController : MonoBehaviour
{
    ScrollView chatMessagesContainer;
    VisualElement messageSuggestionsContainer;
    public Messages messagesScript;
    private ChatMessage[] _messages;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ChatController Start");
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        chatMessagesContainer = root.Q<ScrollView>("ChatMessagesContainer");
        messageSuggestionsContainer = root.Q<VisualElement>("MessageSuggestionsContainer");
        _messages = messagesScript.getChatMessages();
        ChatResponse chatResponse = new ChatResponse("ICH BIN RESPONSE A");
        ChatResponse chatResponse2 = new ChatResponse("ICH BIN RESPONSE B");

        ChatMessage message = new ChatMessage(
            1,
            new[] { 1, 2, 3 },
            "Hello World",
            new[] { chatResponse, chatResponse2 }
        );
        AddToChatMessagesContainer(message);
        addMessagetoSuggestionsContainer(1);
        // Load first Suggestions
    }

    void AddToChatMessagesContainer(ChatMessage chatMessage)
    {
        // Takes ChatMassage-Object and puts it into sent Chat Box ("sends it")
        // Using ChatMessagesContainer in UI
        // Searches for noted answer and sets it into Chat Box too
        // Uses next void to display all new suggestions (for for IDs)
        // For (chatResponse in chatressponses){
        //      chatMessagesContainer.append(chatResponse.getMessage());
        // }

        Debug.Log("AddToChatMessagesContainer");
        VisualElement msgContainer = new VisualElement();
        msgContainer.AddToClassList("chatMessageContainer");
        Label msg = new Label(chatMessage.text);
        msg.AddToClassList("chatMessageRight");
        msgContainer.Add(msg);

        chatMessagesContainer.Add(msgContainer);

        foreach (ChatResponse chatResponse in chatMessage.responses)
        {
            VisualElement responseContainer = new VisualElement();
            responseContainer.AddToClassList("chatMessageContainer");
            if (chatResponse.text != "")
            {
                Label response = new Label(chatResponse.text);
                response.AddToClassList("chatMessageLeft");
                responseContainer.Add(response);
            }
            else
            {
                //IDK please add what to do when image added
            }
            chatMessagesContainer.Add(responseContainer);
        }
    }

    void addMessagetoSuggestionsContainer(int id)
    {
        // Searches for new suggestion with noted ID
        // Puts the text into suggestionBox

        var chatMessage = Array.Find(_messages, e => e.id == id);
        Button messageSuggestion = new Button();
        messageSuggestion.text = chatMessage.text;
        messageSuggestion.AddToClassList("chatSuggestion");
        messageSuggestionsContainer.Add(messageSuggestion);
    }
}
