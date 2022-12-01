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

        //-------------help 14. April-----------------
          ChatResponse message5Response = new ChatResponse(
            "Scan doch mal die Tür ein?"
        );
        ChatMessage message5 = new ChatMessage(
            5,
            new[] { 6 },
            "Bin angekommen, was kann ich tun?",
            new[] { message3Response }
        );

          ChatResponse message6Response = new ChatResponse(
            "Schick mir ein Bild davon!"
        );
        ChatMessage message6 = new ChatMessage(
            6,
            new[] { 7 },
            "Ich habe was gefunden!",
            new[] { message6Response }
        );

          ChatResponse message7Response = new ChatResponse(
            "Schick mir ein Bild davon!"
        );
        ChatMessage message7 = new ChatMessage(
            7,
            new[] { 8 },
            "Ich habe was gefunden!",
            new[] { message7Response }
        );


        ChatResponse message8Response = new ChatResponse(
            "Oh das ist ja nett von Ellie. Vielleicht solltest du dir erstmal einen Überblick verschaffen. Guck mal nach einem Gebäudeplan"
        );
        ChatMessage message8 = new ChatMessage(
            8,
            new[] { non },
            "",
            new[] { message8Response }
        );

           //-------------Bild gefundenhelp 16. April-----------------
       
        ChatMessage message9 = new ChatMessage(
            9,
            new[] { 10 },
            "Da ist schon wieder dieser Fiete. Wer ist das? ",
            new[] { }
        );

          ChatResponse message10Response = new ChatResponse(
            "Vielleicht ist das der Vater?"
        );
        ChatMessage message10 = new ChatMessage(
            10,
            new[] { 7 },
            "",//Hier Bild anfügen
            new[] { message10Response }
        );

          ChatResponse message11Response = new ChatResponse(
            "Das weiß ich nicht"
        );
        ChatMessage message11 = new ChatMessage(
            11,
            new[] {},
            "Aber die scheint ihn ja nicht mal zu mögen? Die kann ja anscheinend nichts mit ihm anfangen?",
            new[] { message11Response }
        );

        
           //-------------HELP am 16. April-----------------

          ChatResponse message12Response = new ChatResponse(
            "Guck doch mal obs n schwarzes Brett gibt "
        );
        ChatMessage message12 = new ChatMessage(
            12,
            new[] { },
            "Ich weiß nicht weiter...",
            new[] { message12Response }
        );


        //-------------HELP am 20. April-----------------

          ChatResponse message13Response = new ChatResponse(
            "Die haben sich gerne Briefe geschickt. Vielleicht findest du etwas, was damit zu tun hat "
        );
        ChatMessage message13 = new ChatMessage(
            13,
            new[] { 14},
            "Ich weiß nicht weiter...",
            new[] { message13Response }
        );


        ChatResponse message14Response = new ChatResponse(
            "Vielleicht gibt es Briefkästen, bei denen du nachschauen kannst"
        );
        ChatMessage message14 = new ChatMessage(
            14,
            new[] {},
            "Wo denn?",
            new[] { message14Response }
        );

        //-------------20. April Brief gefunden
        
        ChatMessage message15 = new ChatMessage(
            15,
            new[] { 16 },
            "",//Hier Bild vom Brief anfügen
            new[] { }
        );


        ChatResponse message16Response = new ChatResponse(
            "Sind die “versprochen??"
        );
        ChatResponse message16Response2 = new ChatResponse(
            "Obwohl, der scheint nur so zu tun..."
        );
        ChatMessage message16 = new ChatMessage(
            16,
            new[] { 17 },
            "Diese Ellie scheint auch nicht viel von Fiete zu halten.",
            new[] { message16Response,message16Response2}
        );


        ChatMessage message17 = new ChatMessage(
            17,
            new[] { 18 },
            "",//Hier Bild von Lochkarte anfügen Brief anfügen
            new[] { }
        );
        
        ChatResponse message18Response = new ChatResponse(
            "Das ist ne Lochkarte, damit stempelt man Zeiten. Das hatte ich auch in meiner Firma."
        );
         ChatMessage message18 = new ChatMessage(
            18,
            new[] { 19 },
            "Weißt du, was das ist?",
            new[] { message18Response}
        );

        ChatResponse message19Response = new ChatResponse(
            "Vielleicht gibt es eine Stechuhr, bei der du mehr rausfinden kannst"
        );
         ChatMessage message19 = new ChatMessage(
            19,
            new[] {  },
            "Was mach ich damit?",
            new[] { message19Response}
        );

        ChatMessage[] chatMessageArray = { startMessage, message2, message3 };
        return chatMessageArray;
    }
}