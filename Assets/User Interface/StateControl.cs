using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StateControl : MonoBehaviour
{
    StoredObject myStored;
    // Start is called before the first frame update
    void Start()
    {
        
        
        try
        {
            StoredObject storedObject =DataPersistanceController.LoadData();
          
            //ChatController.LoadScore(storedObject,  _messages, messagesScript);
        }catch(FileNotFoundException e)
        {
            Debug.Log("No Object found");
        }
    }

    public static int foundObject(int id){
         Debug.Log("Found Object, adding to storedobject");
          try
        {
            StoredObject storedObject =DataPersistanceController.LoadData(); 
            storedObject.collectedObjects.Add(id);
            DataPersistanceController.PersistData(storedObject);  
        }catch(FileNotFoundException e)
        {
            Debug.Log("No Storedobject found");
        }
    }
    public static void AddWrittenMessage(int id){
        Debug.Log("ADDING");
          try
        {
            StoredObject storedObject =DataPersistanceController.LoadData(); 
            int i=1;
            storedObject.sentMessages.Add(id);
            DataPersistanceController.PersistData(storedObject);  
        }catch(FileNotFoundException e)
        {
            Debug.Log("No Object found");
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
