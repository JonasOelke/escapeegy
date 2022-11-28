using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChatResponse;

public class ChatMessage : MonoBehaviour
{
    int id;
    int[] nextIds;
    bool sent=false;
    string text;
    bool available=false;
    ChatResponse[] responses;
    public GameObject photo;
    
}
