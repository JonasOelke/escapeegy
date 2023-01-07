using System.Collections.Generic;

public class InventoryItemToMessageIdMap
{
    public static Dictionary<string, int> Map = new Dictionary<string, int>()
    {

        {"ElliesBrief1", 15 },
        {"Lochkarte", 17 },
        {"Fragezeichen", 20 },
        {"MaggiesTagebucheintrag2", 10 },
        {"MaggiesTagebucheintrag3", 24 },
        {"MaggiesTagebucheintrag4", 34 },
        {"ElliesBrief2", 34 },     
        {"Verlaufsbericht1", 49 },
        {"Verlaufsbericht2", 49 },
        {"Verlaufsbericht3", 49 },
        {"Klinikarbeit", 53 },
        {"Kliniksaal", 54 },
        {"FietesBesuch", 56 },
        {"Bildschnipsel1", 55 },
        {"Bildschnipsel2", 55 },
        {"Bildschnipsel3", 55 },
        {"Bildschnipsel4", 55 },
        {"Bildschnipsel5", 55 },
        {"FietesBesuch", 56 },
        {"BettieUndMaggie", 57 },
        {"Nestbau", 58 },
        { "DrogenWerbung", 60 }
        //Wenn ein Asset gesendet wurde, das nicht in dieser Liste ist, soll es als nachricht 62 gesendet werden
    };
}
