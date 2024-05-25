using UnityEngine;

[System.Serializable]
public class Constructor
{
    public string name;
    public int age;

    public Constructor(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}
