using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DataPersistanceController : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text outputText;
    public DataPersistanceModel dataPersistance;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        outputText.text = inputField.text;
        dataPersistance.inputValue = inputField.text;
        //PersistData();
    }

    static string ToJson(StoredObject obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public static StoredObject LoadData()
    {
        string data = FileManager.LoadFromFile("escepeegy70.json");
        Debug.Log(data + "AAAAAAAAAAAAAAAAAAAAaa");
        StoredObject storedObject =
            data != ""
                ? JsonUtility.FromJson<StoredObject>(data)
                : throw new FileNotFoundException();
        return storedObject;
    }

    public static bool PersistData(StoredObject storedObject)
    {
        return FileManager.WriteToFile("escepeegy70.json", ToJson(storedObject));
    }
}
