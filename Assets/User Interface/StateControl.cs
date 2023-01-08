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
        GameControll myGameController = new GameControll();

        GameObject foundObject = GameObject.Find(name);
        foundObject.SetActive(false);
        try
        {
            StoredObject storedObject = DataPersistanceController.LoadData();
            if (storedObject.collectedObjects.Contains(name))
            {
                Debug.Log(name + " already exists");
            }
            else
            {
                storedObject.collectedObjects.Add (name);
                //Hier von mygamecontroller den state index bekomnmen und dann mit der steState von storedobject den state setzen.-----------------------------------------------------------------------------
                myGameController.LinearityCheck(name);
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
