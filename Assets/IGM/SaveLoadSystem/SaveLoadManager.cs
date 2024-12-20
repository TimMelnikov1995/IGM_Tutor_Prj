using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Newtonsoft.Json; // com.unity.nuget.newtonsoft-json. Вбить это в PackadgeManager в (нажать плюсик) Add packadge by name.
using Newtonsoft.Json.Linq;
//using YG;

public class SaveLoadManager
{
    List<SaveContainer> _saveContainers = new List<SaveContainer>();
    List<object> _registredClasses = new List<object>();

    bool _loaded = false;



    void TypeHelper(ref object obj)
    {
        if(obj.GetType() == typeof(Int64))
            obj = Convert.ToInt32(obj);

        if (obj.GetType() == typeof(double))
            obj = Convert.ToSingle(obj);
    }

    void ArrayHelper(ref object obj, Type type)
    {
        if (obj.GetType() == typeof(JArray))
        {
            JArray jArray = (JArray)obj;
            obj = jArray.ToObject(type);
        }
    }



    void Load(string gameData)
    {
        if (gameData == null || gameData == "")
            return;

        SaveData saveData = JsonConvert.DeserializeObject<SaveData>(gameData);
        _saveContainers = saveData.SaveContainers;

        foreach (object saveClass in _registredClasses)
        {
            List<SaveLoadObjectInfo> infoList = SaveLoadAttributeFinder.GetAttributeInProperties(saveClass);

            foreach (SaveLoadObjectInfo info in infoList)
            {
                foreach (var saveContainer in _saveContainers)
                {
                    if (info.Name == saveContainer.Name)
                    {
                        //Debug.Log("Load: " + info.Object + " Value: " + saveContainer.Value);
                        TypeHelper(ref saveContainer.Value);
                        ArrayHelper(ref saveContainer.Value, info.ObjectType);
                        info.PropertyInfo.SetValue(info.Object, saveContainer.Value);
                    }
                }
            }
        }
    }



    void LoadYG()
    {
        //if (YandexGame.SDKEnabled == true)
        //{
        //    GetYgLoad();
        //}

        //YandexGame.GetDataEvent += GetYgLoad;
    }

    void GetYgLoad()
    {
        //string gameData = YandexGame.savesData.gameData;
        //Load(gameData);
    }

    void SaveYG(string gameData)
    {
        //YandexGame.savesData.gameData = gameData;
        //YandexGame.SaveProgress();
    }



    public void Register(object saveClass)
    {
        _registredClasses.Add(saveClass);
    }

    public void Unregister(object saveClass)
    {
        _registredClasses.Remove(saveClass);
    }

    public void Save()
    {
        if (_loaded == false) 
            return;

        Debug.Log("Save");

        foreach (object saveClass in _registredClasses)
        {
            List<SaveLoadObjectInfo> infoList = SaveLoadAttributeFinder.GetAttributeInProperties(saveClass);

            foreach (SaveLoadObjectInfo info in infoList)
            {
                //print("Save: " + info.Name + " Value: " + info.PropertyInfo.GetValue(info.Object));

                SaveContainer saveContainer = new SaveContainer(info.Name, info.PropertyInfo.GetValue(info.Object));
                _saveContainers.Add(saveContainer);
            }
        }

        SaveData saveData = new SaveData(_saveContainers);
        string saveDataToJSON = JsonConvert.SerializeObject(saveData);
        PlayerPrefs.SetString("Data", saveDataToJSON);

        SaveYG(saveDataToJSON);
    }

    public void Load()
    {
        Debug.Log("Load");

        _loaded = true;

        LoadYG();
        if (PlayerPrefs.HasKey("Data") == false)
            return;

        string saveDataInPrefs = PlayerPrefs.GetString("Data");
        Load(saveDataInPrefs);
    }

    public void Clear()
    {
        Debug.Log("Clear");
        PlayerPrefs.DeleteAll();
    }
}

[Serializable]
public class SaveContainer
{
    public string Name;
    public object Value;

    public SaveContainer(string name, object value)
    {
        Name = name;
        Value = value;
    }
}

public class SaveLoadObjectInfo
{
    public readonly string Name;
    public readonly PropertyInfo PropertyInfo;
    public readonly object Object;
    public readonly Type ObjectType;


    public SaveLoadObjectInfo(string name, PropertyInfo propertyInfo, object @object, Type objectType)
    {
        Name = name;
        PropertyInfo = propertyInfo;
        Object = @object;
        ObjectType = objectType;
    }
}

[Serializable]
public class SaveData
{
    public List<SaveContainer> SaveContainers;

    public SaveData(List<SaveContainer> saveContainers)
    {
        SaveContainers = saveContainers;
    }
}