using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DataPersistanceController : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text outputText;
    public DataPersistanceModel dataPersistance;

    public void SaveData()
    {
        outputText.text = inputField.text;
        dataPersistance.inputValue = inputField.text;
        //PersistData();
    }

    static string ToJson(StoredObjectSerializable obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public static StoredObject LoadData()
    {
        StoredObjectSerializable storedObjectSerializable = LoadFromFile();
        return new StoredObject(storedObjectSerializable);
    }

    static StoredObjectSerializable LoadFromFile()
    {
        string data = FileManager.LoadFromFile("escepeegy2.json");
        StoredObjectSerializable storedObjectSerializable =
            data != ""
                ? JsonUtility.FromJson<StoredObjectSerializable>(data)
                : throw new FileNotFoundException();

        return storedObjectSerializable;
    }

    public static void DeleteData()
    {
        FileManager.DeleteFile("escepeegy2.json");
        SceneManager.LoadScene("UniMap");
    }

    public static bool PersistData(StoredObject storedObject)
    {
        StoredObjectSerializable storedObjectSerializable = new StoredObjectSerializable(
            storedObject
        );
        Debug.Log(ToJson(storedObjectSerializable));
        return FileManager.WriteToFile("escepeegy2.json", ToJson(storedObjectSerializable));
    }
}
