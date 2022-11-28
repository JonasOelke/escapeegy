using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChatMessage;

public class ChatController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Load first Suggestions
    }

    void addToChatMessagesContainer(ChatMessage chatMessage){
        // Takes ChatMassage-Object and puts it into sent Chat Box ("sends it")
        // Using ChatMessagesContainer in UI
        // Searches for noted answer and sets it into Chat Box too
        // Uses next void to display all new suggestions (for for IDs)
        // For (chatResponse in chatressponses){
        //      chatMessagesContainer.append(chatResponse.getMessage());
        // }
    }

    void addMessagetoSuggestionsContainer(int id){
        // Searches for new suggestion with noted ID
        // Puts the text into suggestionBox

    }
}
