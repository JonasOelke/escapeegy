using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using System.Threading;
public class ChatController : MonoBehaviour
{
    ScrollView chatMessagesContainer;
    VisualElement messageSuggestionsContainer;
    public Messages messagesScript;
    private ChatMessage[] _messages;
    public Messages emmasPic;
    

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        chatMessagesContainer = root.Q<ScrollView>("ChatMessagesContainer");
        messageSuggestionsContainer = root.Q<VisualElement>("MessageSuggestionsContainer");
        var backButton = root.Q<Button>("BackButton");
        backButton.clicked += () =>
        {
            GetComponentInParent<UIController>().BackToMenu();
        };

        ClearChat();
        _messages = messagesScript.getChatMessages();
        addMessagetoSuggestionsContainer(2);
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

    void ClearChat()
    {
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
            if(chatResponse.text!="NEE"){
                VisualElement responseContainer = new VisualElement();
                responseContainer.AddToClassList("chatMessageContainer");
                if (chatResponse.photo == "")
                {
                    Label response = new Label(chatResponse.text);
                    response.AddToClassList("chatMessageLeft");
                    responseContainer.Add(response);
                }
                else
                {   Label response = new Label(chatResponse.text);
                    switch(chatResponse.photo){
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
                StartCoroutine(Wait(()=> chatMessagesContainer.Add(responseContainer)));
            }
                
            Debug.Log("Delay starts");
            StartCoroutine(Wait(()=>AddMessageToContainerAndSetNextSuggestion(chatMessage)));
            Debug.Log("Delay ends");
        }
        
    }
    
    void AddMessageToContainerAndSetNextSuggestion(ChatMessage chatMessage)
    {
        foreach (int nextSuggestion in chatMessage.nextIds){
            if(nextSuggestion!=0){
                addMessagetoSuggestionsContainer(nextSuggestion);
                Debug.Log(nextSuggestion);
            }
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
        messageSuggestion.clicked += () =>
        {
            AddToChatMessagesContainer(chatMessage);
            messageSuggestion.parent.Remove(messageSuggestion);
        };
        messageSuggestionsContainer.Add(messageSuggestion);
    }
}
