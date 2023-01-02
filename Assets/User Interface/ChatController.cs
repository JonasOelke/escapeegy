using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.IO;

using System.Threading;
public class ChatController : MonoBehaviour
{
    ScrollView chatMessagesContainer;
    VisualElement messageSuggestionsContainer;
    public Messages messagesScript;
    public Items itemsScript;
    private ChatMessage[] _messages;
    private Item[] _items;
    public Messages emmasPic;
    private bool firstOpened=true;
    public UIController uiController;
    StoredObject storedObject;

    // Start is called before the first frame update
    void Start()
    {

        //Sektion für stored Object bei Start
        try
        {
            storedObject =DataPersistanceController.LoadData();
            LoadScore(storedObject);
        }catch(FileNotFoundException e)
        {
            StoredObject storedObject = new StoredObject(new List<int>());
            DataPersistanceController.PersistData(storedObject);  
            SceneManager.LoadScene("Intro_Slides1");
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
        _messages = messagesScript.getChatMessages();
        _items = itemsScript.getItems();
        addMessagetoSuggestionsContainer(1);
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
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        chatMessagesContainer = root.Q<ScrollView>("ChatMessagesContainer");
        messageSuggestionsContainer = root.Q<VisualElement>("MessageSuggestionsContainer");
        var backButton = root.Q<Button>("BackButton");
        
         //Sektion für stored Object bei Start
        try
        {
            storedObject =DataPersistanceController.LoadData();
            LoadScore(storedObject);
        }catch(FileNotFoundException e)
        {
            StoredObject storedObject = new StoredObject(new List<int>());
            DataPersistanceController.PersistData(storedObject);  
            SceneManager.LoadScene("Intro_Slides1");
        }


        Debug.Log("BBBBBBBBBBBBBBBB"+ storedObject);
        backButton.clicked += () =>
        {
            GetComponentInParent<UIController>().BackToMenu();
        };

        if (storedObject.firstOpened)
        { 
            Debug.Log("DDDDDDDDDDDDDDDDDD");
          //  uiController.BackToMenu();
           // uiController.OpenChat();
            storedObject.setOpened(false);
            DataPersistanceController.PersistData(storedObject); 
        }
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

    public void AddToChatMessagesContainer(ChatMessage chatMessage)
    {
        //Storing stuff
        StateControl.AddWrittenMessage(chatMessage.id);
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
            if (chatResponse.text != "NEE")
            {
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
                StartCoroutine(Wait(() => chatMessagesContainer.Add(responseContainer)));
            }

           
        } Debug.Log("Delay starts");
            StartCoroutine(Wait(() => AddMessageToContainerAndSetNextSuggestion(chatMessage)));
            Debug.Log("Delay ends");
    }

    void AddMessageToContainerAndSetNextSuggestion(ChatMessage chatMessage)
    {
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
        // Searches for new suggestion with noted ID
        // Puts the text into suggestionBox

        var chatMessage = Array.Find(_messages, e => e.id == id);
        Button messageSuggestion = new Button();
        if(chatMessage.summary==""){
            messageSuggestion.text = chatMessage.text;
        }else{
            messageSuggestion.text = chatMessage.summary;
        }
        messageSuggestion.AddToClassList("chatSuggestion");
        messageSuggestion.clicked += () =>
        {
            AddToChatMessagesContainer(chatMessage);
            messageSuggestion.parent.Remove(messageSuggestion);
        };
        messageSuggestionsContainer.Add(messageSuggestion);
    }


    
void LoadScore(StoredObject myObject)
{
    Debug.Log("LOOOOOOOOOOOOOOOOOOOOOOAD");
    foreach (var chatMessageID in myObject.sentMessages)
        {
            if(chatMessageID<100){
                foreach(ChatMessage chatMessage in _messages){
                    if(chatMessage.id==chatMessageID){
                        AddToChatMessagesContainer(chatMessage);
                    }
                }
            }else{
                //Wenn id >100 ist es keine Message, sondern ein bild. Dann muss auf das zugehörige Item zugegriffen werden und die Responses da rausgesucht werden
                foreach(Item item in _items){
                    //Item aus Item Array raussuchen
                    if(item.id==chatMessageID){
                       
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

    foreach(int itemID in myObject.collectedObjects){
        foreach(Item item in _items){
            if(item.id==itemID){
                item.setFound(true);
            }
        }
    }   

}
}