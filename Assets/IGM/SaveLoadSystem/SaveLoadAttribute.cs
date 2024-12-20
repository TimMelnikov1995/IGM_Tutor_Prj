using System;

[AttributeUsage(AttributeTargets.Property)]
public class SaveLoadAttribute : Attribute
{
    public string Name { get; }

    public SaveLoadAttribute(string name)
    {
        Name = name;
    }
}