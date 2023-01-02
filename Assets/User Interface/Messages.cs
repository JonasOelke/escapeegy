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
            //Message to put in Responses Array if the Message should not have a response
           ChatResponse noResponse = new ChatResponse(
            "NEE",
            ""
        );
        // Start Message and responses
        ChatResponse startMessageResponse1 = new ChatResponse(
            "Hey du, schön von dir zu hören! Ich schau mal kurz.",
            ""
        );
        ChatResponse startMessageResponse2 = new ChatResponse(
            "Ich habe diese Todesanzeige gefunden und einen Tagebucheintrag von einer Lieselotte",
            ""
        );
        ChatMessage startMessage = new ChatMessage(
            1,
            new[] { 2 },
            "Hallo du, ich habe ein Foto gefunden, zu dem Papa meinte, dass du mehr wissen könntest. Ich interessiere mich für unsere Familiengeschichte, weil ich das für die Schule machen muss. Hast du noch mehr Infos dazu? Wer waren die beiden?",
            "Ich habe ein Foto gefunden!",
           
            new[] { startMessageResponse1, startMessageResponse2 }
        );

        // Second Message
        /*ChatResponse message2Response = new ChatResponse(
            "\n\n\n",
            "Lochkarte"
        );*/

         ChatResponse message2Response = new ChatResponse(
            "Ich glaube Lieselotte meint das Insititut für Geburtshilfe in Uhlenhorst, zumindest geht das aus ihren anderen Tagebucheinträgen hervor. Ich weiß nicht wer Fiete ist, vielleicht finde ich noch was dazu.",
            ""
        );

        ChatMessage message2 = new ChatMessage(
            2,
            new[] { 3 },
            "Oh wild. Weißt du, von welcher Anstalt die Rede ist, oder warum Lieselotte zweifelt? Und wer bitteschön ist Fiete?",
            "Weißt du mehr zur Anstalt oder den Menschen?",
            new[] { message2Response }
        );

        // Third Message
        ChatResponse message3Response = new ChatResponse(
            "Ja, klar. Vielleicht gibt es da eine/n <ersten Startpunkt> einfügen.",
            ""
        );
        ChatMessage message3 = new ChatMessage(
            3,
            new[] { 0 },
            "Ich hab’ herausgefunden, dass die Geburtsklinik inzwischen der Kunst- und Mediencampus Hamburg ist. Denkst du, ich kann da einfach hingehen?",
            "Die Geburtsklinik ist jetzt ein Campus.",
            new[] { message3Response }
        );

        //-------------help 14. April-----------------
          ChatResponse message5Response = new ChatResponse(
            "Scan doch mal die Tür ein?",
            ""
        );
        ChatMessage message5 = new ChatMessage(
            5,
            new[] { 6 },
            "Bin angekommen, was kann ich tun?",
            "",
            new[] { message5Response }
        );

          ChatResponse message6Response = new ChatResponse(
            "Schick mir ein Bild davon!",
            ""
        );
        ChatMessage message6 = new ChatMessage(
            6,
            new[] { 7 },
            "Ich habe was gefunden!",
            "",
            new[] { message6Response }
        );

          ChatResponse message7Response = new ChatResponse(
            "Schick mir ein Bild davon!",
            ""
        );
        ChatMessage message7 = new ChatMessage(
            7,
            new[] { 8 },
            "Ich habe was gefunden!",
            "",
            new[] { message7Response }
        );


        ChatResponse message8Response = new ChatResponse(
            "Oh das ist ja nett von Ellie. Vielleicht solltest du dir erstmal einen Überblick verschaffen. Guck mal nach einem Gebäudeplan",
            ""
        );
        ChatMessage message8 = new ChatMessage(
            8,
            new[] { 0 },
            "",
            "",
            new[] { message8Response }
        );

           //-------------Bild gefundenhelp 16. April-----------------
       
        ChatMessage message9 = new ChatMessage(
            9,
            new[] { 10 },
            "Da ist schon wieder dieser Fiete. Wer ist das? ",
            "",
            new[] { noResponse}
        );

          ChatResponse message10Response = new ChatResponse(
            "Vielleicht ist das der Vater?",
            ""
        );
        ChatMessage message10 = new ChatMessage(
            10,
            new[] { 7 },
            "",//Hier Bild anfügen
            "",
            new[] { message10Response }
        );

          ChatResponse message11Response = new ChatResponse(
            "Das weiß ich nicht",
            ""
        );
        ChatMessage message11 = new ChatMessage(
            11,
            new[] {0},
            "Aber die scheint ihn ja nicht mal zu mögen?",
            "",
            new[] { message11Response }
        );

        
           //-------------HELP am 16. April-----------------

          ChatResponse message12Response = new ChatResponse(
            "Guck doch mal obs n schwarzes Brett gibt ",
            ""
        );
        ChatMessage message12 = new ChatMessage(
            12,
            new[] { 0},
            "Ich weiß nicht weiter...",
            "",
            new[] { message12Response }
        );


        //-------------HELP am 20. April-----------------

          ChatResponse message13Response = new ChatResponse(
            "Die haben sich gerne Briefe geschickt. Vielleicht findest du etwas, was damit zu tun hat ",
            ""
        );
        ChatMessage message13 = new ChatMessage(
            13,
            new[] { 14},
            "Ich weiß nicht weiter...",
            "",
            new[] { message13Response }
        );


        ChatResponse message14Response = new ChatResponse(
            "Vielleicht gibt es Briefkästen, bei denen du nachschauen kannst",
            ""
        );
        ChatMessage message14 = new ChatMessage(
            14,
            new[] {0},
            "Wo denn?",
            "",
            new[] { message14Response }
        );

        //-------------20. April Brief gefunden
        
        ChatMessage message15 = new ChatMessage(
            15,
            new[] { 16 },
            "",//Hier Bild vom Brief anfügen
            "",
            new[] {noResponse }
        );


        ChatResponse message16Response = new ChatResponse(
            "Sind die “versprochen??",
            ""
        );
        ChatResponse message16Response2 = new ChatResponse(
            "Obwohl, der scheint nur so zu tun...",
            ""
        );
        ChatMessage message16 = new ChatMessage(
            16,
            new[] { 17 },
            "Diese Ellie scheint auch nicht viel von Fiete zu halten.",
            "",
            new[] { message16Response,message16Response2}
        );


        ChatMessage message17 = new ChatMessage(
            17,
            new[] { 18 },
            "",//Hier Bild von Lochkarte anfügen Brief anfügen
            "",
            new[] {noResponse }
        );
        
        ChatResponse message18Response = new ChatResponse(
            "Das ist ne Lochkarte, damit stempelt man Zeiten. Das hatte ich auch in meiner Firma.",
            ""
        );
         ChatMessage message18 = new ChatMessage(
            18,
            new[] { 19 },
            "Weißt du, was das ist?",
            "",
            new[] { message18Response}
        );

        ChatResponse message19Response = new ChatResponse(
            "Vielleicht gibt es eine Stechuhr, bei der du mehr rausfinden kannst",
            ""
        );
         ChatMessage message19 = new ChatMessage(
            19,
            new[] { 0 },
            "Was mach ich damit?",
            "",
            new[] { message19Response}
        );


    //---------------StechUhr Messages
        ChatResponse message20Response = new ChatResponse(
            "Leg es übereinander",
            ""
        );
         ChatMessage message20 = new ChatMessage(
            20,
            new[] { 21 },
            "Das ist nur Kaudawelsch. Was mach ich damit?",
            "",
            new[] { message20Response}
        );
        
       
         ChatMessage message21 = new ChatMessage(
            21,
            new[] { 22 },
            "",//Hier Bild einfügen
            "",
            new[] { noResponse}
        );


        ChatResponse message22Response = new ChatResponse(
            "Wie wärs wenn du dir erstmal einen Kaffee holst?",
            ""
        );
         ChatMessage message22 = new ChatMessage(
            22,
            new[] { 0 },
            "Was meinst du heißt das?",
            "",
            new[] { message22Response}
        );
        

    //---------Hilfe 2. Stock---------
        ChatResponse message23Response = new ChatResponse(
            "guck dich doch erstmal ein wenig um?",
            ""
        );
         ChatMessage message23 = new ChatMessage(
            23,
            new[] { 0 },
            "Ich weiß nicht weiter!",
            "",
            new[] { message23Response}
        );

    //---------------21. April
    
         ChatMessage message24 = new ChatMessage(
            24,
            new[] { 25 },
            "",//Hier Bild einfügen
            "",
            new[] { noResponse}
        );

        ChatResponse message25Response = new ChatResponse(
            "",
            "Tagebucheintrag25.April"  //hier bild einfügen
        );
        ChatResponse message25Response2 = new ChatResponse(
            "Das erinnert mich an etwas. Moment.",
            ""
        );
         ChatMessage message25 = new ChatMessage(
            25,
            new[] { 26 },
            "Wer ist denn Helmut? Und was ist da passiert?",
            "Wer ist denn Helmut?",
            new[] { message25Response, message25Response2}
        );

        ChatResponse message26Response = new ChatResponse(
            "Die Einträge sind von Liselotte. Sie war Maggies Schwester. ",
            ""
        );
         ChatMessage message26 = new ChatMessage(
            26,
            new[] { 27 },
            "Von wem kommt dieser Tagebucheintrag?",
            "",
            new[] { message26Response}
        );

        ChatMessage message27 = new ChatMessage(
            27,
            new[] { 0 },
            "Liselotte denkt wohl, dass was auf dem Geburtstag passiert sein könnte.",
            "",
            new[] { noResponse}
        );

        //----------------25. April

        ChatMessage message28 = new ChatMessage(
            28,
            new[] { 29 },
            "", //Hier Bild einfügen
            "",
            new[] { noResponse}
        );

        ChatResponse message29Response = new ChatResponse(
            "Klostefrau Melissengeist in der Schwangerschaft ist ja nicht besonders toll… Das arme Kind. ",
            ""
        );
        ChatMessage message29 = new ChatMessage(
            29,
            new[] { 30 },
            "Hysterisch? Was ist passiert?",
            "",
            new[] { message29Response}
        );

        ChatResponse message30Response = new ChatResponse(
            "Das war damals einfach so... ",
            ""
        );
        ChatMessage message30 = new ChatMessage(
            30,
            new[] { 0 },
            "Alles an diesem Bericht ist scheiße. Was soll das bitte mit der Hysterie?",
            "Der Bericht ist kacke...",
            new[] { message30Response}
        );

        //----------------27. April
        ChatResponse message31Response = new ChatResponse(
            "Auf der Krankenakte steht ihre Spindnummer",
            ""
        );
        ChatMessage message31 = new ChatMessage(
            31,
            new[] { 32 },
            "Welcher Spind ist wohl ihrer?",
            "",
            new[] { message31Response}
        );
        ChatResponse message32Response = new ChatResponse(
            "schau dich mal um",
            ""
        );
        ChatResponse message32Response2 = new ChatResponse(
            "Vielleicht ist es ihr Geburtstag?",
            "" //Das hier nur wenn tuch schon gefunden wurde
        );
        ChatMessage message32 = new ChatMessage(
            32,
            new[] { 0 },
            "Oh mist, ich brauche den Spindcode",
            "",
            new[] { message32Response, message32Response2}
        );

        //Nach lösen der Spindgeschichte
        
        ChatMessage message33 = new ChatMessage(
            33,
            new[] { 0 },
            "Es war das Geburtsdatum des Kindes",
            "",
            new[] { noResponse}
        );

        //Wenn Brief und Tagebuch aus spind gefunden
      
        ChatMessage message34 = new ChatMessage(
            34,
            new[] { 35 },
            "",//Hier Bild einfügen
            "",
            new[] { noResponse}
        );

        ChatResponse message35Response = new ChatResponse(
            "Oh Gott... Hat er sie vergewaltigt?",
            ""
        );
        ChatMessage message35 = new ChatMessage(
            35,
            new[] { 36 },
            "Fiete is Arschloch. Kein Wunder dass sie aufgelöst war. Furchtbar, dass die Schwestern sie als Hysterisch eingestuft haben",
           "Fiete ist ein Arsch",
            new[] { message35Response}
        );

        ChatResponse message36Response = new ChatResponse(
            "...",
            ""
        );
        ChatResponse message36Response2 = new ChatResponse(
            "Wie geht es dir?",
            ""
        );
        ChatMessage message36 = new ChatMessage(
            36,
            new[] { 37,38,39 },
            "Scheiße... Das darf doch nicht wahr sein",
            "Scheiße..",
            new[] { message36Response, message36Response2}
        );

         ChatMessage message37 = new ChatMessage(
            37,
            new[] { 0 },
            "Geht so",
            "",
            new[] { noResponse}
        );
          ChatMessage message38 = new ChatMessage(
            38,
            new[] { 0 },
            "Alles gut",
            "",
            new[] { noResponse}
        );
          ChatMessage message39 = new ChatMessage(
            39,
            new[] { 0 },
            "Ich brauch ne kurze Pause",
            "",
            new[] { noResponse}
        );

        // ------------------23. März
        ChatResponse message40Response = new ChatResponse(
            "Ich hab da was gefunden. Tipp: mach das nicht so mit unserer Familie:",
            ""
        );
        ChatResponse message40Response2 = new ChatResponse(
            "",
            "Tagebucheintrag26.Dezember"
        );
        ChatMessage message40 = new ChatMessage(
            40,
            new[] { 41 },
            "Hast du einen Eintrag zu Weihnachten?",
            "",
            new[] { message40Response, message40Response2}
        );

        ChatResponse message41Response = new ChatResponse(
           "Klingt, als hätte Maggie einiges mit ihrer Familie durchmachen müssen ",
            ""
        );
        ChatMessage message41 = new ChatMessage(
            41,
            new[] { 0 },
            "Boah, die Familie klingt ja nicht so nice. Und Fiete wirkt sehr übergriffig…",
            "Die Familie klingt uncool...",
            new[] { message41Response}
        );


        // ---------------------3. Mai
        ChatResponse message42Response = new ChatResponse(
           "Gibts eigentlich noch mehr Krankenakten?",
            ""
        );
        ChatMessage message42 = new ChatMessage(
            42,
            new[] { 43 },
            "Ich weiß nicht weiter",
            "",
            new[] { message42Response}
        );

        ChatResponse message43Response = new ChatResponse(
           "Guck doch mal beim Ärztezimmer, vielleicht gibt es da etwas. Das sollte auf dem Gebäudeplan markiert sein.?",
            ""
        );
        ChatMessage message43 = new ChatMessage(
            43,
            new[] { 44 },
            "Ich hab nichts weiter gefunden",
            "",
            new[] { message43Response}
        );

          ChatResponse message44Response = new ChatResponse(
           "Was soll man dazu noch sagen...",
            ""
        );
        ChatMessage message44 = new ChatMessage(
            44,
            new[] { 0 },
            "", //Hier Bild einfügen
            "",
            new[] { message44Response}
        );


        // ---------------------5. Mai--------
        ChatMessage message45 = new ChatMessage(
            45,
            new[] { 46 },
            "", //Hier Bild einfügen
            "",
            new[] { noResponse}
        );

        ChatResponse message46Response = new ChatResponse(
           "Das sieht für mich nach einem verschlüsselten Brief aus. Die Zahl in der Ecke könnte der Schlüssel sein.",
            ""
        );
     
         ChatMessage message46 = new ChatMessage(
            46,
            new[] { 47 },
            "Was soll das denn sein?",
            "",
            new[] { message46Response}
        );


        ChatResponse message47Response2 = new ChatResponse(
           "Ich glaube, ich habe noch ein Buch darüber. Gib mir einen Moment",
            ""
        );
        ChatResponse message47Response = new ChatResponse(
           "",
            "decryptedLetter"
        );
         ChatResponse message47Response3 = new ChatResponse(
           "Das ist 2 tage vor ihrem Todestag!!",
            ""
        );
        
         ChatMessage message47 = new ChatMessage(
            47,
            new[] { 0 },
            "Ich weiß nicht, was ich machen soll",
            "",
            new[] { message47Response, message47Response2}
        );


        //--------------------------7. Mai
        ChatMessage message48 = new ChatMessage(
            48,
            new[] { 49 },
            "",//Hier Bild einfügen
            "",
            new[] {  noResponse}
        );


         ChatResponse message49Response = new ChatResponse(
           "Ohjemine. Hätte nicht gedacht, dass das so ein großer Fall ist",
            ""
        );
        ChatResponse message49Response2 = new ChatResponse(
           "",
            "Tagebucheintrag10.Mai"//Hier Bild einfügen
        );
         ChatMessage message49 = new ChatMessage(
            49,
            new[] { 50 },
            "Herzversagen?! Jetzt verstehe ich, warum Lieselotte das alles verdächtig findet",
            "Herzversagen?! SUS",
            new[] { message49Response,message49Response2}
        );

         ChatResponse message50Response = new ChatResponse(
           "Wollen wir darüber gleich telefonieren?",
            ""
        );
         ChatMessage message50 = new ChatMessage(
            50,
            new[] { 51 },
            "Das bricht mir das Herz",
            "",
            new[] { message50Response}
        );

        ChatMessage message51 = new ChatMessage(
            51,
            new[] { 0 },
            "Hier habe ich kein Empfang. Ich ruf dich an sobald ich draußen bin. ",
            "Ich hab grade keinen Empfang...",
            new[] { noResponse}
        );

        //----------Findet Schächtelchen/Ampulle im Regal

        //Vorher Bild senden
        ChatResponse message52Response = new ChatResponse(
           "War so üblich damals",
            ""
        );
        ChatMessage message52 = new ChatMessage(
            52,
            new[] { 0 },
            "Fiete war “drauf”? Drogen-drauf? ",
            "",
            new[] { message52Response}
        );

        //------------Schwanger pflichertfüllung
         //Vorher Bild senden
        ChatResponse message53Response = new ChatResponse(
           "Boah, so schwanger hätte ich ja nicht mehr arbeiten wollen",
            ""
        );
        ChatMessage message53 = new ChatMessage(
            53,
            new[] { 0 },
            "Schau was ich gefunden habe ",
            "",
            new[] { message53Response}
        );


        //------------KlinikSäle
         //Vorher Bild senden
        ChatResponse message54Response = new ChatResponse(
           "Von Privatsühäre halten die wohl nichts",
            ""
        );
        ChatMessage message54 = new ChatMessage(
            54,
            new[] { 0 },
            "Schau was ich gefunden habe ",
            "",
            new[] { message54Response}
        );


        //------------Besuch von Fiete
         //Vorher Bild von einzelnem Schnipsel senden
        ChatResponse message55Response = new ChatResponse(
           "Sieht aus, als wäre das ein Stück von einem Foto. Vielleicht kannst du die anderen Teile auch noch finden.",
            ""
        );
        ChatMessage message55 = new ChatMessage(
            55,
            new[] { 0 },
            "Was ist das denn?",
            "",
            new[] { message55Response}
        );

        //Vorher Bild von allen Schnipseln senden
        ChatResponse message56Response = new ChatResponse(
           "Das ist wohl dieser Fiete… ",
            ""
        );
        ChatMessage message56 = new ChatMessage(
            56,
            new[] { 0 },
            " Ich hab alle Schnipsel gefunden! Maggie sieht aber nicht so glücklich aus.",
            "Ich hab alle Schnipsel gefunden!...",
            new[] { message56Response}
        );

        //----------BFF Support Snippet
        //Vorher Bild von Freunden senden
        ChatResponse message57Response = new ChatResponse(
           " Die beiden scheinen Spaß zu haben. Der Ort sieht sehr markant aus, vielleicht findet du den Vogel.",
            ""
        );
        ChatMessage message57 = new ChatMessage(
            57,
            new[] { 0 },
            " Guck mal!",
            "",
            new[] { message57Response}
        );

        //----------Schnuffeltuch
        //Vorher Bild  senden
        ChatResponse message58Response = new ChatResponse(
           "Das ist bestimmt der Errechnete Geburtstermin vom Kind",
            ""
        );
        ChatMessage message58 = new ChatMessage(
            58,
            new[] { 0 },
            "Die scheinen sich schon gut auf das Kind vorzubereiten. Auf der Rückseite habe ich ein Datum gefunden",
            "Die bereiten sich auf das Kind vor!...",
            new[] { message58Response}
        );


        //----------Abschiedsparty WG
        //Vorher Bild  senden
        ChatResponse message59Response = new ChatResponse(
           "Die WG scheint sehr nett gewesen zu sein",
            ""
        );
        ChatMessage message59 = new ChatMessage(
            59,
            new[] { 0 },
            "Sieht aus wie eine Abschiedsparty",
            "",
            new[] { message59Response}
        );


        //----------Merkblatt
        //Vorher Bild  senden
        ChatResponse message60Response = new ChatResponse(
           "Die sollen ihren Kindern Kuhmilch füttern? Krass!",
            ""
        );
        ChatMessage message60 = new ChatMessage(
            60,
            new[] { 0 },
            "Das ist wohl das Merkblatt, das Maggie bekommen hat",
            "",
            new[] { message60Response}
        );

        //----------Drogenwerbung
        //Vorher Bild  senden
        ChatResponse message61Response = new ChatResponse(
           " Ja, da hab ich neulich eine Doku drüber gesehen",
            ""
        );
        ChatMessage message61 = new ChatMessage(
            61,
            new[] { 0 },
            "Warte mal, damals wurden Drogen einfach als Medizin verteilt?",
            "",
            new[] { message61Response}
        );




        ChatMessage[] chatMessageArray = { startMessage, message2, message3, message5, message6, message7, 
        message8,message9, message10, message11,message12,message13,message14,message15,message16,message17,
        message18,message19,message20,message21,message22,message23, message24, message25, message26,message27, 
        message28,message29,message30,message31,message32,message33, message34, message35, message36,message37, 
        message38,message39,message40,message41,message42,message43, message44, message45, message46,message47, 
        message48,message49,message50,message51,message52,message53, message54, message55, message56,message57, 
        message58,message59,message60,message61, };

        ChatResponse[] chatResponseArray = {message8Response,message10Response,message44Response};

        return chatMessageArray;

    }

     public ChatResponse[] getChatResponses()
    {
          ChatResponse message8Response = new ChatResponse(
            "Oh das ist ja nett von Ellie. Vielleicht solltest du dir erstmal einen Überblick verschaffen. Guck mal nach einem Gebäudeplan",
            ""
        );

         ChatResponse message10Response = new ChatResponse(
            "Vielleicht ist das der Vater?",
            ""
        );

          ChatResponse message44Response = new ChatResponse(
           "Was soll man dazu noch sagen...",
            ""
        );
        ChatResponse[] chatResponseArray = {message8Response,message10Response,message44Response};

        return chatResponseArray;

    }
}