using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// [File I/O]
/// This class will provide actions with read/write from File JSON
/// </summary>
public class JsonHandler : MonoBehaviour
{
    public UserData data;

    private string file = "savedUserData.txt";

    //(Public) Write data to File
    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }

    //(Public) Read data from File
    public void Load()
    {
        data = new UserData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    //(Internal) Write data to File
    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    //(Internal) Read data from File
    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if(File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        } else
        {
            //Debug.LogWarning("File not found");
            //throw exception to handle
            throw new System.Exception("File not found");
        }
    }

    //(Internal) get file link
    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}