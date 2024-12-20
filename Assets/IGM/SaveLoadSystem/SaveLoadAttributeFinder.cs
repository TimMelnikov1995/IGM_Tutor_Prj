using System.Reflection;
using System;
using System.Collections.Generic;

public class SaveLoadAttributeFinder
{
    public static List<SaveLoadObjectInfo> GetAttributeInProperties(object obj)
    {
        List<SaveLoadObjectInfo> infoList = new List<SaveLoadObjectInfo>();

        SaveLoadAttribute att;

        Type type = obj.GetType();

        PropertyInfo[] propertyInfo = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance);

        for (int i = 0; i < propertyInfo.Length; i++)
        {
            att = (SaveLoadAttribute)Attribute.GetCustomAttribute(propertyInfo[i], typeof(SaveLoadAttribute));
            if (att == null)
            {
                //Debug.Log("No attribute in member function: " + MyMemberInfo[i].ToString());
            }
            else
            {
                //Debug.Log(t.FullName + ":     " + MyMemberInfo[i].ToString() + ":     " + att.Name);

                SaveLoadObjectInfo info = new SaveLoadObjectInfo(att.Name, propertyInfo[i], obj, propertyInfo[i].PropertyType);
                infoList.Add(info);
            }
        }

        return infoList;
    }
}