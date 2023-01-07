using System.Collections;
using System.Collections.Generic;
using System.IO;
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
                DataPersistanceController.PersistData (storedObject);
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("No Storedobject found");
        }
    }

    public static void AddWrittenMessage(int id)
    {
        Debug.Log("addWrittenMessage to stored object");
        try
        {
            StoredObject storedObject = DataPersistanceController.LoadData();
            if (storedObject.sentMessages.Contains(id))
            {
                Debug.Log(id + " already exists");
            }
            else
            {
                storedObject.sentMessages.Add (id);
                DataPersistanceController.PersistData (storedObject);
            }
            
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("No Object found");
        }
    }
}
