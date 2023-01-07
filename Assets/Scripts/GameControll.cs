using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class GameControll : MonoBehaviour
{

 [SerializeField] GameObject[] Findables;


   
   [SerializeField] int activeSectionIndex;
     StoredObject storedObject = DataPersistanceController.LoadData();
    

//MaggiesBrief nach Verlaufsbericht2 als Textnachricht
//"MaggiesTagebucheintrag4" zwi ElliesBrief2 und Verlaufsbericht
 public List<string> ObjectNamesLinear = new List<string>()
 {
    "MaggiesTagebucheintrag1", "MaggiesTagebucheintrag2", "ElliesBrief1",  "MaggiesTagebucheintrag3", "Aufnahmebericht",
    "Verlaufsbericht1", "MaggiesTagebucheintrag4", "ElliesBrief2",  "Verlaufsbericht2", "Fragezeichen", "Verlaufsbericht3", 
    "Leichenschein"

  
 };
  

//Bedingungen: Lochkarte + interassentesPapier = LochkarteMerge 
//Schnipsel 1-5 = FietesBesuch
//Drogenwerbung bei Ampulle
 public List<string> objectsUnLinear = new List<string>(){
     "Klinikarbeit","Kliniksaal","FietesBesuch", "Bildschnipsel1",
      "Bildschnipsel2","Bildschnipsel3","Bildschnipsel4","Bildschnipsel5","BettieUndMaggie","Nestbau","WGAbschied","Drogenwerbung", "InteressantesPapier",
      "Lochkarte","LochkarteMerge"};



//Logik: Leichenschein+Verlaufsbericht3 und Spindrätsel als SpecialCases für den Counter, weil's zwei Objekte in der Linearity sind
public void LinearityCheck(string nameObj){
   
   var collectedObjects = storedObject.collectedObjects;
   SetVisibility(activeSectionIndex);

    
   if (collectedObjects.Contains("Verlaufsbericht1") && collectedObjects.Contains("Aufnahmebericht"))
   {
      activeSectionIndex = 6;
      }
      if (collectedObjects.Contains("MaggiesTagebucheintrag4")&& collectedObjects.Contains("ElliesBrief2")){
         activeSectionIndex = 8;
      }
    if (objectsUnLinear.Contains(nameObj)){
        Debug.Log("it's unlinear");
    }

    else if (ObjectNamesLinear[activeSectionIndex] == nameObj){
        activeSectionIndex +=1;
        Debug.Log("Linearity "+ nameObj + "IndexCheck" + ObjectNamesLinear[activeSectionIndex]);
    }
    else {
        Debug.Log("Linearity Fail");
        }
}

//sets the Visibility of linear GameObjects
//Lochkarte + Spindrätsel müssen noch auftauchen als Bedingung -> Lochkarte gelöst, dann erst Next. Und Spindrätse
public void SetVisibility(int activeSectionIndex){

      var collectedObjects = storedObject.collectedObjects;

   switch(activeSectionIndex){
      case 0:
         Findables[0].SetActive(true);
      break;
      case 1: 
         Findables[1].SetActive(true);
      break;
      case 2: 
         Findables[2].SetActive(true);
      break;
       case 3: 
         Findables[3].SetActive(true);
         break;
      case 4:
         Findables[4].SetActive(true);
         Findables[5].SetActive(true);
      break;
        case 5: 
          Debug.Log("I'm flying 5");
         break;
      case 6: 
         Findables[6].SetActive(true); //MaggieTB4
         Findables[7].SetActive(true); //ElliesBrief2
         break;
      case 7:
        Debug.Log("I'm flying 7");
         break;
      case 8: 
       if(  collectedObjects.Contains("LieselottesTagebucheintrag3")){
         Findables[8].SetActive(true); //Verlaufsbericht2
           };  
         break;
      case 9: 
        Findables[9].SetActive(true); //MaggiesBrief
         break;
         case 10:
         Findables[10].SetActive(true);
         Findables[11].SetActive(true);
         break;
   }
}

 public void SectionsFinished(){
    //endgame
    Debug.Log("LinearStory Doneth");
 }

}
