using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    public ChatMessage[] getChatMessages()
    {
        //-------------------------------------Intro Messages-----------------------------
        // Start Message and responses
        ChatResponse startMessageResponse1 = new ChatResponse(
            "Hey du, schön von dir zu hören! Ich schau mal kurz."
        );
        ChatResponse startMessageResponse2 = new ChatResponse(
            "Ich habe diese Todesanzeige gefunden und einen Tagebucheintrag von einer Lieselotte"
        );
        ChatMessage startMessage = new ChatMessage(
            1,
            new[] { 2, },
            "Hallo du, ich habe ein Foto gefunden, zu dem Papa meinte, dass du mehr wissen könntest. Ich interessiere mich für unsere Familiengeschichte, weil ich das für die Schule machen muss. Hast du noch mehr Infos dazu? Wer waren die beiden?",
            new[] { startMessageResponse1, startMessageResponse2 }
        );

        // Second Message
        ChatResponse message2Response = new ChatResponse(
            "Ich glaube Lieselotte meint das Insititut für Geburtshilfe in Uhlenhorst, zumindest geht das aus ihren anderen Tagebucheinträgen hervor. Ich weiß nicht wer Fiete ist, vielleicht finde ich noch was dazu."
        );
        ChatMessage message2 = new ChatMessage(
            2,
            new[] { 3 },
            "Oh wild. Weißt du, von welcher Anstalt die Rede ist, oder warum Lieselotte zweifelt? Und wer bitteschön ist Fiete?",
            new[] { message2Response }
        );

        // Third Message
        ChatResponse message3Response = new ChatResponse(
            "Ja, klar. Vielleicht gibt es da eine/n <ersten Startpunkt> einfügen."
        );
        ChatMessage message3 = new ChatMessage(
            3,
            new[] { 4 },
            "Ich hab’ herausgefunden, dass die Geburtsklinik inzwischen der Kunst- und Mediencampus Hamburg ist. Denkst du, ich kann da einfach hingehen?",
            new[] { message3Response }
        );

        ChatMessage[] chatMessageArray = { startMessage, message2, message3 };
        return chatMessageArray;
    }
}
