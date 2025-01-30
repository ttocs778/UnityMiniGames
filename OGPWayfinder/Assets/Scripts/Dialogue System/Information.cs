using UnityEngine;

[System.Serializable]
public class Information
{
    public string title;
    [TextArea(10,10)] public string details;
    public bool unlocked;
}
