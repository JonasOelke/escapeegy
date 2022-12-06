using System.Collections;
using System.Collections.Generic;
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
        PersistData();
    }

    string ToJson()
    {
        return JsonUtility.ToJson(dataPersistance);
    }

    public DataPersistanceModel LoadFromJson(string json)
    {
        return JsonUtility.FromJson<DataPersistanceModel>(json);
    }

    void LoadData()
    {
        string data = FileManager.LoadFromFile("escepeegy1.json");
        Debug.Log(data);
        dataPersistance = data != "" ? LoadFromJson(data) : new DataPersistanceModel();
        outputText.text = data != "" ? dataPersistance.inputValue : "--";
    }

    void PersistData()
    {
        FileManager.WriteToFile("escepeegy1.json", ToJson());
    }
}
