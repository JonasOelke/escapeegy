using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class GameControll : MonoBehaviour
{

 [SerializeField] GameObject[] series;

 public bool linearCheck;
    string nameObj;
   [SerializeField] int activeSectionIndex;

 public bool visible =false; 
//MaggiesBrief nach Verlaufsbericht2 als Textnachricht
 public List<string> ObjectNamesLinear = new List<string>()
 {
    "MaggiesTagebucheintrag1", "MaggiesTagebucheintrag2", "ElliesBrief1",  "MaggiesTagebucheintrag3", "Aufnahmebericht",
    "Verlaufsbericht1", "MaggiesTagebucheintrag4",  "ElliesBrief2","LieselottesTagebucheintrag2","Verlaufsbericht2", "Fragezeichen", "Verlaufsbericht3",
    "Leichenschein", "LieselottesTagebucheintrag5"
  
 };
  public List<string> Ahhh= new List<string>()
 {
    "MaggiesTagebucheintrag1", "MaggiesTagebucheintrag2", "ElliesBrief1",  "MaggiesTagebucheintrag3", "Aufnahmebericht",
    "Verlaufsbericht1", "MaggiesTagebucheintrag4",  "ElliesBrief2","LieselottesTagebucheintrag2","Verlaufsbericht2", "Fragezeichen", "Verlaufsbericht3",
    "Leichenschein", "LieselottesTagebucheintrag5"
  
 };


//Bedingungen: Lochkarte + interassentesPapier = LochkarteMerge 
//Schnipsel 1-5 = FietesBesuch
//Drogenwerbung bei Ampulle
 public List<string> objectsUnLinear = new List<string>(){
      "LieselottesTagebucheintrag1", "LieselottesTagebucheintrag3", "LieselottesTagebucheintrag4","Klinikarbeit","Kliniksaal","FietesBesuch", "Bildschnipsel1",
      "Bildschnipsel2","Bildschnipsel3","Bildschnipsel4","Bildschnipsel5","BettieUndMaggie","Nestbau","WGAbschied","Drogenwerbung", "InteressantesPapier",
      "Lochkarte","LochkarteMerge"};


public void ItemCheck(){
    name = Ahhh[0];

     if (ObjectNamesLinear.Count >= activeSectionIndex)
        {
            SectionsFinished();
           // return;
        }

    if (objectsUnLinear.Contains(nameObj)){
        Debug.Log("it's unlinear");
    }
    else if (ObjectNamesLinear[activeSectionIndex] == nameObj){
        activeSectionIndex +=1;
        Debug.Log("Linearity "+ name + "IndexCheck" + ObjectNamesLinear[activeSectionIndex]);
    }
    else {
        Debug.Log("Linearity Fail");
        }
}


 public void SectionsFinished(){
    //endgame
    Debug.Log("LinearStory Doneth");
 }

}
