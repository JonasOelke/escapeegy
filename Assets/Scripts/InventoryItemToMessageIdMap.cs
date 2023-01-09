using System.Collections.Generic;

public class InventoryItemToMessageIdMap
{
    public static Dictionary<string, int> Map = new Dictionary<string, int>()
    {
        { "Lochkarte", 16 },
        { "Fragezeichen", 20 },
        { "MaggiesTagebucheintrag2", 9 },
        { "MaggiesTagebucheintrag3", 23 },
        { "MaggiesTagebucheintrag4", 33 },
        { "ElliesBrief2", 33 },
        { "Verlaufsbericht1", 48 },
        { "Verlaufsbericht2", 48 },
        { "Verlaufsbericht3", 48 },
        { "Klinikarbeit", 52 },
        { "Kliniksaal", 53 },
        { "FietesBesuch", 55 },
        { "Bildschnipsel1", 54 },
        { "Bildschnipsel2", 54 },
        { "Bildschnipsel3", 54 },
        { "Bildschnipsel4", 54 },
        { "Bildschnipsel5", 54 },
        { "BettieUndMaggie", 58 },
        { "Nestbau", 57 },
        { "DrogenWerbung", 59 },
        { "BriefVerschluesselt", 44 }
        //Wenn ein Asset gesendet wurde, das nicht in dieser Liste ist, soll es als nachricht 62 gesendet werden
    };
}
