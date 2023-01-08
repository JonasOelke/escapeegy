using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateControl : MonoBehaviour
{
    StoredObject myStored;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            DataPersistanceController.LoadData();
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("No Object found");
        }
    }



    public static void SaveFoundObject(string name)
    {
        GameControll myGameController = GameObject.Find("StateControl").GetComponent<GameControll>();

        GameObject foundObject = GameObject.Find(name);
        foundObject.SetActive(false);
        try
        {
            StoredObject storedObject = DataPersistanceController.LoadData();
            if (storedObject.collectedObjects.Contains(name))
            {
                Debug.Log(name + " already exists");
                //Sorgt bei re-öffnen der app daür, dass die gespeicherten objekte in den den State des GameControll übernommen werden
                  myGameController.LinearityCheck(name); 

            }
            else
            {
         
                myGameController.LinearityCheck(name);       
                storedObject.collectedObjects.Add(name);
                //Hier wird myGamecontroller der state index genommen und dann mit der steState von storedobject den state gesetzt
                storedObject.setState(myGameController.activeSectionIndex);
                DataPersistanceController.PersistData (storedObject);
         
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("No Storedobject found");
        }
    }

    public static void AddWrittenMessage(ChatMessage chatMessage)
    {
        Debug.Log("addWrittenMessage to stored object");
        try
        {
            StoredObject storedObject = DataPersistanceController.LoadData();
            if (storedObject.sentMessages.Any((x) => chatMessage.id == x.id))
            {
                Debug.Log("Message already exists");
            }
            else
            {
                storedObject.sentMessages.Add(chatMessage);
                DataPersistanceController.PersistData(storedObject);
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("No Object found");
        }
    }
}
