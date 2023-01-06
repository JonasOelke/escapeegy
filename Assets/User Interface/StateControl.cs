using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateControl : MonoBehaviour
{
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
        try
        {
            StoredObject storedObject = DataPersistanceController.LoadData();
            if (storedObject.collectedObjects.Contains(name))
            {
                Debug.Log(name + " already exists");
            }
            else
            {
                storedObject.collectedObjects.Add(name);
                DataPersistanceController.PersistData(storedObject);
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("No Storedobject found");
        }
    }

    public static void AddWrittenMessage(int id)
    {
        Debug.Log("ADDING");
        try
        {
            StoredObject storedObject = DataPersistanceController.LoadData();
            storedObject.sentMessages.Add(id);
            DataPersistanceController.PersistData(storedObject);
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("No Object found");
        }
    }
}
